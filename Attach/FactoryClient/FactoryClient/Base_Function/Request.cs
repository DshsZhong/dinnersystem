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

namespace FactoryClient
{
    public class Request
    {
        string cookieHeader;
        public string uname = "";
        const string host = "https://dinnersystem.ddns.net";
        public Request(string id, string pswd)
        {
            string url = host + "/dinnersys_beta/backend/backend.php?cmd=login&device_id=factory_client&id=" + id + "&hash=" + create_hash(id, pswd);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            WebResponse wr = req.GetResponse();
            cookieHeader = wr.Headers["Set-cookie"];
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(wr.GetResponseStream(), encode);
            string reponse = readStream.ReadToEnd();
            JObject obj;
            try { obj = JsonConvert.DeserializeObject<JObject>(reponse); }
            catch (Exception e) { throw new Exception(reponse); }

            bool able = false;
            foreach (JToken item in obj["valid_oper"])
            {
                able |= (item.ToString(Newtonsoft.Json.Formatting.None) == "\"update_dish\"");
                able |= (item.ToString(Newtonsoft.Json.Formatting.None) == "\"select_facto\"");
                able |= (item.ToString(Newtonsoft.Json.Formatting.None) == "\"select_cafet\"");
            }
            uname = obj["name"].ToString();
            if (!able) throw new Exception("Access denied");
        }

        string create_hash(string id ,string password)
        {
            SHA512 sha = new SHA512CryptoServiceProvider();
            int now = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            JObject json = new JObject();
            json["id"] = id;
            json["password"] = password;
            json["time"] = now.ToString();
            string local_hashed = BitConverter.ToString(sha.ComputeHash(Encoding.ASCII.GetBytes(json.ToString(Newtonsoft.Json.Formatting.None))));
            local_hashed = local_hashed.Replace("-", "").ToLower();
            return local_hashed;
        }

        public JArray Get_Order(string lower_bound ,string upper_bound ,bool model = false)
        {
            string url = host + "/dinnersys_beta/backend/backend.php?cmd=select_" + (model ? "other" : "facto") + 
                "&esti_start=" + lower_bound + "&esti_end=" + upper_bound + (model ? "&history=true" : "");
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
            string url = host + "/dinnersys_beta/backend/backend.php?cmd=show_dish";
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
                count += 1;
                wr.Close();
                invoker((int)Math.Ceiling((double)count / suffix.Count * 100));
            }
        }

        public List<int> Get_Version()
        {
            string url = host + "/dinnersys_beta/frontend/u_move_u_dead/version.txt";
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Headers.Add("Cookie", cookieHeader);
            WebResponse wr = req.GetResponse();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(wr.GetResponseStream(), encode);
            JObject array = JsonConvert.DeserializeObject<JObject>(readStream.ReadToEnd());
            List<int> version = new List<int>();
            foreach (JToken v in array["factory"])
                version.Add(v.ToObject<int>());
            return version;
        }
    }
}
