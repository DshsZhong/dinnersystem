using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Threading;
using System.IO;

namespace bank_server
{
    delegate void Execute(Tuple<dynamic, NetworkStream> input);
    class Internet
    {
        Execute function;
        Thread[] listen_thread;
        IPAddress allow;
        int Maximum_Threads = 100;
        int Threads = 0;

        public Internet(IPAddress allow, Execute func)
        {
            function = func;
            this.allow = allow;
        }

        public void Start_Listen()
        {
            IPAddress self = new IPAddress(new byte[4] { 127, 0, 0, 1 });
            IPHostEntry iphostentry = Dns.GetHostEntry(Dns.GetHostName());
            listen_thread = new Thread[iphostentry.AddressList.Length];
            for (int i = 0; i != iphostentry.AddressList.Length; i++)
            {
                TcpListener listener = new TcpListener(iphostentry.AddressList[i], 8787);
                listen_thread[i] = new Thread(new ParameterizedThreadStart(Listen));
                listen_thread[i].Start(listener);
            }
        }

        public void Stop_Listen()
        {
            foreach (Thread t in listen_thread) t.Abort();
        }

        void Listen(object param)
        {
            TcpListener listener = param as TcpListener;
            listener.Start();
            while (true)
            {
                while (Threads >= Maximum_Threads) //Server overload.
                    Thread.Sleep(1000);
                Thread t = new Thread(new ParameterizedThreadStart(Run));
                TcpClient client = listener.AcceptTcpClient();
                /*if ((client.Client.RemoteEndPoint as IPEndPoint).Address != allow) // unavailable ip.
                    continue;*/
                Tuple<NetworkStream, Thread> tuple = new Tuple<NetworkStream, Thread>(client.GetStream(), t);
                t.Start(tuple);
                Threads += 1;
            }
        }

        void Run(object p)
        {
            Tuple<NetworkStream, Thread> param = p as Tuple<NetworkStream, Thread>;
            NetworkStream nws = param.Item1;
            byte[] tmp = new byte[65536];
            nws.Read(tmp, 0, 65536);
            string data = Encoding.ASCII.GetString(tmp);
            function(new Tuple<dynamic ,NetworkStream>(JsonConvert.DeserializeObject(data) ,nws));
            param.Item2.Abort();
            Threads -= 1;
        }
    }
}

