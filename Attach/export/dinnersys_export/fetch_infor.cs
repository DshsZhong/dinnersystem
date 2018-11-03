using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dinnersys_export
{
    class fetch_infor
    {
        string id, pswd, date , cookieHeader;
        public fetch_infor(string id, string pswd, string date)
        {
            this.date = date;
            string url = "http://dinnersystem.ddns.net/dinnersys_beta/backend/backend.php?cmd=login&id=" + id + "&password=" + pswd;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            WebResponse wr = req.GetResponse();
            cookieHeader = wr.Headers["Set-cookie"];
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(wr.GetResponseStream(), encode);
        }

        public JArray get()
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://dinnersystem.ddns.net/dinnersys_beta/backend/backend.php?cmd=select_other&cafet=true&esti_start=" + date + "-00:00:00&esti_end=" + date + "-23:59:59");
            req.Headers.Add("Cookie", cookieHeader);
            WebResponse wr = req.GetResponse();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(wr.GetResponseStream(), encode);
            JArray array = JsonConvert.DeserializeObject<JArray>(readStream.ReadToEnd());
            return array;
        }
    }
}
