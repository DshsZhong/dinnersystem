using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Configuration;
using System.Collections.Specialized;

namespace FactoryClient
{
    public class Request
    {
        string cookieHeader;
        public string uname = "";
        public List<string> valid_opers = new List<string>();
        static string host = Properties.Settings.Default.remote_host;

        public Request(string id, string pswd)
        {
            string url = host + "/dinnersys_beta/backend/backend.php?cmd=login&device_id=factory_client&id=" + id + "&password=" + pswd;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            WebResponse wr = req.GetResponse();
            cookieHeader = wr.Headers["Set-cookie"];
            StreamReader readStream = new StreamReader(wr.GetResponseStream(), Encoding.GetEncoding("utf-8"));
            string reponse = readStream.ReadToEnd();
            JObject obj;
            try { obj = JsonConvert.DeserializeObject<JObject>(reponse); }
            catch (Exception e) { throw new Exception(reponse); }

            bool able = false;
            foreach (JToken item in obj["valid_oper"])
            {
                able |= (item.ToString(Newtonsoft.Json.Formatting.None) == "\"update_dish\"");
                able |= (item.ToString(Newtonsoft.Json.Formatting.None) == "\"select_facto\"");
                able |= (item.ToString(Newtonsoft.Json.Formatting.None) == "\"select_other\"");
                valid_opers.Add(item.ToString(Newtonsoft.Json.Formatting.None));
            }
            uname = obj["name"].ToString();
            if (!able) throw new Exception("Access denied");
        }

        public JArray Get_Order(string lower_bound, string upper_bound, bool model = false)
        {
            string url = host + "/dinnersys_beta/backend/backend.php?cmd=select_" + (model ? "other" : "facto") +
                "&esti_start=" + lower_bound + "&esti_end=" + upper_bound + (model ? "&history=true" : "");
            if (model && (from item in valid_opers where item == "\"select_other\"" select item).Count() == 0)
                throw new Exception("Access denied.");

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Headers.Add("Cookie", cookieHeader);
            WebResponse wr = req.GetResponse();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(wr.GetResponseStream(), encode);
            JArray array = JsonConvert.DeserializeObject<JArray>(readStream.ReadToEnd());
            JArray ret = new JArray();
            foreach (JToken order in array)
            {
                bool alive = false;
                foreach (JToken payment in order["money"]["payment"])
                    alive |= (payment["name"].ToString(Formatting.None) == "\"cafeteria\"" && payment["paid"].ToString(Formatting.None) == "\"true\"") ||
                        (payment["name"].ToString(Formatting.None) == "\"payment\"" && payment["paid"].ToString(Formatting.None) == "\"true\"");
                if (alive) ret.Add(order);
            }
            return ret;
        }

        public JArray Get_Dish()
        {
            string url = host + "/dinnersys_beta/backend/backend.php?cmd=show_dish&sortby=dish_id";
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Headers.Add("Cookie", cookieHeader);
            WebResponse wr = req.GetResponse();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(wr.GetResponseStream(), encode);
            JArray array = JsonConvert.DeserializeObject<JArray>(readStream.ReadToEnd());
            return array;
        }

        public void Update_Dish(List<string> suffix, UpdateProgress invoker)
        {
            int count = 0;
            foreach (string tmp in suffix)
            {
                string url = host + "/dinnersys_beta/backend/backend.php?cmd=update_dish" + tmp;
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Headers.Add("Cookie", cookieHeader);
                WebResponse wr = req.GetResponse();
                StreamReader readStream = new StreamReader(wr.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                string resp = readStream.ReadToEnd();
                if (resp != "Nothing to update." && resp != "Successfully updated food.")
                    throw new Exception("Unable to update dish: " + resp);
                wr.Close();
                invoker((int)Math.Ceiling((double)count / suffix.Count * 100));
                count += 1;
            }
        }

        public List<JToken> Get_Version()
        {
            string url = host + "/dinnersys_beta/frontend/u_move_u_dead/version.txt";
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Headers.Add("Cookie", cookieHeader);
            WebResponse wr = req.GetResponse();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(wr.GetResponseStream(), encode);
            JObject array = JsonConvert.DeserializeObject<JObject>(readStream.ReadToEnd());
            List<JToken> version = new List<JToken>();
            foreach (JToken v in array["factory"])
                version.Add(v);
            return version;
        }

        public void Report_Error(string error)
        {
            string url = host + "/dinnersys_beta/backend/backend.php?cmd=error_report";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("Cookie", cookieHeader);
            var postData = new
            {
                data = new
                {
                    user_name = uname,
                    error_string = error,
                    config = Properties.Settings.Default,
                    location = AppDomain.CurrentDomain.BaseDirectory
                }
            };
            byte[] byteArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(postData));
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(byteArray, 0, byteArray.Length);
            }
            request.GetResponse();
        }
    }
}