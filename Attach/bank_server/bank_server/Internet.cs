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
        TcpListener[] listeners;
        IPAddress allow;
        int Maximum_Threads = 100;
        int Threads = 0;
        bool Keep_Alive;

        public Internet(IPAddress allow, Execute func)
        {
            function = func;
            this.allow = allow;
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
                catch (SocketException e) { continue; /*Usally it means we want to close the thread. So just ignore the Exception*/ }

                Thread t = new Thread(new ParameterizedThreadStart(Run));
                if ((client.Client.RemoteEndPoint as IPEndPoint).Address.ToString() != allow.ToString()) // unavailable ip.
                    continue;
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

