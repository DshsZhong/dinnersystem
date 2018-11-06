using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace dinnersys_export
{
    class fetch_infor
    {
        string id, pswd, start ,end , cookieHeader;
        public fetch_infor(string id, string pswd, string start ,string end)
        {
            this.start = start;
            this.end = end;

            string url = "http://dinnersystem.ddns.net/dinnersys_beta/backend/backend.php?cmd=login&id=" + id + "&password=" + pswd;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            WebResponse wr = req.GetResponse();
            cookieHeader = wr.Headers["Set-cookie"];
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(wr.GetResponseStream(), encode);
        }

        public JArray get(bool history)
        {
            String url = "http://dinnersystem.ddns.net/dinnersys_beta/backend/backend.php?cmd=select_other&cafet=true&esti_start=" + start + "-00:00:00&esti_end=" + end + "-23:59:59";
            url += (history ? "&history=true" : "");
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Headers.Add("Cookie", cookieHeader);
            WebResponse wr = req.GetResponse();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(wr.GetResponseStream(), encode);
            JArray array = JsonConvert.DeserializeObject<JArray>(readStream.ReadToEnd());
            return array;
        }
    }
}
