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
        int delay = 1000;
        public int Delay
        {
            get { return delay; }
            set { delay = value; }
        }

        int Id = 0;
        enum DwFlag : int
        {
            Down = 0,
            Up = 2
        }

        Queue<Tuple<List<string>, int, Action>> waiter = new Queue<Tuple<List<string>, int, Action>>();
        public KeyPress()
        {
            Task.Run(() => Cycle());
        }

        public void Run(List<string> data, Action callback)
        {
            int self = Id++;
            Tuple<List<string>, int, Action> sender = new Tuple<List<string>, int, Action>(data, self, callback);
            waiter.Enqueue(sender);
            while (waiter.Count != 0 && waiter.Peek().Item2 <= self)
                Thread.Sleep(100);
        }

        void Cycle()
        {
            while(true)
            {
                while (waiter.Count == 0) Thread.Sleep(100);
                List<string> commands = waiter.Peek().Item1;
                foreach (string s in commands) Write(s);
                Flush();
                waiter.Peek().Item3.Invoke();
                waiter.Dequeue();
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
                Thread.Sleep(delay);
            }
            keyPress(0xD);
            Thread.Sleep(delay);
        }

        void Flush()
        {
            keyPress(0x7B);
            Thread.Sleep(delay);
        }
    }
}
