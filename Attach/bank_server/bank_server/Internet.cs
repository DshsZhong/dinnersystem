using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Threading;

namespace bank_server
{
    delegate string Execute(dynamic input);
    class Internet
    {
        Execute function;
        Thread[] listen_thread;
        TcpListener[] listeners;
        int Maximum_Threads = 10;
        int Threads = 0;
        bool Keep_Alive;

        public Internet(Execute func)
        {
            function = func;
        }

        public void Start_Listen()
        {
            Keep_Alive = true;
            IPAddress self = new IPAddress(new byte[4] { 127, 0, 0, 1 });
            IPHostEntry iphostentry = Dns.GetHostEntry(Dns.GetHostName());
            listen_thread = new Thread[iphostentry.AddressList.Length];
            listeners = new TcpListener[iphostentry.AddressList.Length];
            for (int i = 0; i != iphostentry.AddressList.Length; i++)
            {
                listeners[i] = new TcpListener(iphostentry.AddressList[i], 8787);
                listen_thread[i] = new Thread(new ParameterizedThreadStart(Listen));
                listen_thread[i].Start(listeners[i]);
            }
        }

        public void Stop_Listen()
        {
            Keep_Alive = false;
            for (int i = 0; i != listen_thread.Length; i++)
            {
                listeners[i].Stop();
                listen_thread[i].Abort();
            }
        }

        void Listen(object param)
        {
            TcpListener listener = param as TcpListener;
            listener.Start();
            while (Keep_Alive)
            {
                while (Threads >= Maximum_Threads) //Server overload.
                    Thread.Sleep(1000);

                TcpClient client;
                try { client = listener.AcceptTcpClient(); }
                catch (Exception e) { break; /* Usally it means we want to close the thread. So just ignore the Exception */ }

                Task.Run(() =>
                {
                    NetworkStream nws = client.GetStream();
                    byte[] tmp = new byte[65536];
                    nws.Read(tmp, 0, 65536);
                    string data = Encoding.ASCII.GetString(tmp);

                    string ret = function(JsonConvert.DeserializeObject(data));

                    tmp = new byte[65536];
                    tmp = Encoding.ASCII.GetBytes(ret);
                    nws.WriteTimeout = 1000;
                    nws.Write(tmp, 0, tmp.Length);
                    nws.Close(1000);
                    Threads -= 1;
                });
                Threads += 1;
            }
        } 
    }
}

