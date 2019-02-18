using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;

namespace FactoryClient.Analysis_Function
{
    delegate void Function();
    class Thread_Pool
    {
        Queue<Function> queue;
        bool dispose = false;

        public bool Done = false;
        public Thread_Pool(int threads)
        {
            queue = new Queue<Function>();
            while (threads-- != 0)
                new Thread(new ThreadStart(Run)).Start();
        } 
        ~Thread_Pool() { dispose = true; }

        public void Entask(Function task)
        {
            queue.Enqueue(task);
            Done = false;
        }
        public void Stop() { dispose = true; }
        public int TaskLeft() { return queue.Count; }

        void Run()
        {
            while (!dispose)
            {
                Function f;
                lock (queue)
                {
                    while (queue.Count == 0) Thread.Sleep(100);
                    f = queue.Dequeue();
                }
                f();
                if (queue.Count == 0) Done = true;
            }
        }

    }
}
