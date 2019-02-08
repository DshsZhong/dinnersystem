using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FactoryClient
{
    class Request
    {
        string cookieHeader;
        const string host = "http://localhost";
        public Request(string id, string pswd)
        {
            string url = host + "/dinnersys_beta/backend/backend.php?cmd=login&device_id=factory_client&id=" + id + "&hash=" + create_hash(pswd);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            WebResponse wr = req.GetResponse();
            cookieHeader = wr.Headers["Set-cookie"];
        }

        string create_hash(string password)
        {
            SHA512 sha = new SHA512CryptoServiceProvider();
            int now = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string local_hashed = BitConverter.ToString(sha.ComputeHash(Encoding.ASCII.GetBytes(json)));
            local_hashed = local_hashed.Replace("-", "").ToLower();
            return local_hashed;
        }

        public JArray Get_Order(string lower_bound ,string upper_bound)
        {
            string url = host + "/dinnersys_beta/backend/backend.php?cmd=select_facto&esti_start=" + lower_bound + "&esti_end=" + upper_bound;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Headers.Add("Cookie", cookieHeader);
            WebResponse wr = req.GetResponse();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(wr.GetResponseStream(), encode);
            JArray array = JsonConvert.DeserializeObject<JArray>(readStream.ReadToEnd());
            return array;
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

        /* 
         * id=1
         * dish_name=asdfasdfere
         * charge_sum=123
         * is_vege=PURE 
         * is_idle=false
         * daily_limit=1000 
         */
        public void Update_Dish(List<string> suffix)
        {
            List<Task> waiter = new List<Task>();
            foreach(string tmp in suffix)
            {
                string url = host + "/dinnersys_beta/backend/backend.php?cmd=update_dish" + tmp;
                waiter.Add(Task.Run(() =>
                {
                    HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                    req.Method = "GET";
                    WebResponse wr = req.GetResponse();
                    cookieHeader = wr.Headers["Set-cookie"];
                }));
            }

            // Make this function synchorized.
            foreach (Task t in waiter) t.Wait();
        }
    }
}
