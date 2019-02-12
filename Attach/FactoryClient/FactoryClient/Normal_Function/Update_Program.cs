using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Diagnostics;
using IWshRuntimeLibrary;

namespace FactoryClient
{
    class Update_Program
    {
        const int version = 2;
        const string remote_location = "http://dinnersystem.ddns.net/dinnersys_beta/frontend/u_move_u_dead/dinnersys0.png";

        public bool Updatable { get; set; }
        string local_location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, (version + 1).ToString() + ".png");
        string icon_location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icon.ico");
        string program_shortcut = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "午餐系統.url");
        UpdateProgress invoker;

        public Update_Program(Request req, UpdateProgress invoker)
        {
            this.invoker = invoker;
            List<int> ver = req.Get_Version();
            Updatable = true;
            foreach (int s in ver)
                Updatable &= (version != s);
        }

        public void Update()
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += ((object sender, DownloadProgressChangedEventArgs e) => invoker(e.ProgressPercentage));
                wc.DownloadFileAsync(
                    new System.Uri(remote_location),
                    local_location
                );
            }
        }
        
        public void Finish()
        {
            using (StreamWriter writer = new StreamWriter(program_shortcut))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + local_location);
                writer.WriteLine("IconIndex=0");
                writer.WriteLine("IconFile=" + icon_location);
                writer.Flush();
            }

            Process.Start(program_shortcut);
            Process.GetCurrentProcess().Kill();
        }
    }
}
