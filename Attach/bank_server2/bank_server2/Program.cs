using System;
using System.Net;
using System.Net.Sockets;
using System.Net.Http;
using System.IO;

namespace bank_server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(8787);
            server.Start();
            while(true)
            {
                Socket sock = server.AcceptSocket();
                NetworkStream nws = new NetworkStream(sock);
                StreamWriter sw = new StreamWriter(nws);
                StreamReader sr = new StreamReader(nws);
                Console.WriteLine(sr.ReadLine());
                sw.WriteLine("1000");
                sw.Flush();
                sock.Disconnect(true);
            }
        }
    }
}

