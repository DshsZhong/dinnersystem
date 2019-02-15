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
        public Thread_Pool(int threads)
        {
            queue = new Queue<Function>();
            while (threads-- != 0) Task.Run(() => Run());
        } 
        ~Thread_Pool() { dispose = true; }

        public void Entask(Function task) { queue.Enqueue(task); }
        public void Stop() { dispose = true; }
        public int TaskLeft() { return queue.Count; }

        void Run()
        {
            while (!dispose)
            {
                while (queue.Count == 0) Thread.Sleep(100);
                Function f = queue.Dequeue();
                f();
            }
        }

    }
}
