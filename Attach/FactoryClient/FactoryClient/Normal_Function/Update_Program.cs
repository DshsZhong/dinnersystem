using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace FactoryClient
{
    class Update_Program
    {
        public static string version = ConfigurationManager.AppSettings["version"];
        public static string remote_url = ConfigurationManager.AppSettings["remote_url"];
        public static string remote_name = ConfigurationManager.AppSettings["remote_name"];
        public static string remote_location;
        // Might cause serious problem if the config has been modified.

        public bool Updatable { get; set; }

        string zip_location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "v" + (version + 1).ToString() + ".zip");
        string local_location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\v" + (version + 1).ToString());
        string icon_location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icon.ico");
        string program_shortcut = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "午餐系統.url");

        public Update_Program(Request req)
        {
            List<JObject> ver = req.Get_Version();
            foreach(JObject obj in ver)
            {
                if(obj["version"].ToString() == version)
                {
                    Updatable = obj["updatable"].ToString() == "1";
                    remote_location = String.Format("{0}/v{1}/{2}", remote_url, obj["next"], remote_name);
                }
            }
        }

        public void Update(UpdateProgress invoker)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += ((object sender, DownloadProgressChangedEventArgs e) => invoker(e.ProgressPercentage));
                wc.DownloadFileAsync(
                    new System.Uri(remote_location),
                    zip_location
                );
            }
        }
        
        public void Finish()
        {
            ZipFile.ExtractToDirectory(zip_location, local_location);
            using (StreamWriter writer = new StreamWriter(program_shortcut))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + local_location + "/FactoryClient.exe");
                writer.WriteLine("IconIndex=0");
                writer.WriteLine("IconFile=" + icon_location);
                writer.Flush();
            }

            Process.Start(program_shortcut);
            Process.GetCurrentProcess().Kill();
        }
    }
}
