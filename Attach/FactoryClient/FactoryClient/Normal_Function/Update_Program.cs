using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;
using IWshRuntimeLibrary;

namespace FactoryClient
{
    class Update_Program
    {
        const int version = 5;
        const string remote_location = "http://dinnersystem.ddns.net/dinnersys_beta/factory_client/client.zip";

        public bool Updatable { get; set; }
        string zip_location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "v" + (version + 1).ToString() + ".zip");
        string local_location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\v" + (version + 1).ToString());
        string icon_location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icon.ico");
        string program_shortcut = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "午餐系統.url");

        public Update_Program(Request req)
        {
            List<int> ver = req.Get_Version();
            Updatable = true;
            foreach (int s in ver)
                Updatable &= (version != s);
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
