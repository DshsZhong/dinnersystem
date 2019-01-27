using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace bank_server
{
    class KeyPress
    {
        int Delay = 100;
        int Id = 0;
        enum DwFlag : int
        {
            Down = 0,
            Up = 2
        }

        Queue<Tuple<List<string>, int>> waiter = new Queue<Tuple<List<string>, int>>();
        public KeyPress(int Delay)
        {
            this.Delay = Delay;
            Task.Run(() => Cycle());
        }

        public void Run(List<string> data)
        {
            int self = Id++;
            Tuple<List<string>, int> sender = new Tuple<List<string>, int>(data, self);
            waiter.Enqueue(sender);
            while (waiter.Count != 0 && waiter.Peek().Item2 < self)
                Thread.Sleep(100);
        }

        void Cycle()
        {
            while(true)
            {
                while (waiter.Count == 0) Thread.Sleep(100);
                List<string> commands = waiter.Dequeue().Item1;
                foreach (string s in commands) Write(s);
                Flush();
            }
        }

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        static void keyPress(byte keyName) //Just send the ascii
        {
            keybd_event(keyName, 0, (int)DwFlag.Down, 0);
            keybd_event(keyName, 0, (int)DwFlag.Up, 0);
        }

        void Write(string s)
        {
            byte[] data = Encoding.ASCII.GetBytes(s);
            foreach(byte b in data)
            {
                keyPress(b);
                Thread.Sleep(Delay);
            }
            keyPress(0xD);
            Thread.Sleep(Delay);
        }

        void Flush()
        {
            keyPress(0x7B);
            Thread.Sleep(Delay);
        }
    }
}
