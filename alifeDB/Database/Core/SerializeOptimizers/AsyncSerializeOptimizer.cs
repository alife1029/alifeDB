using System;
using System.Threading;
using System.Threading.Tasks;

namespace alifeDB.Database.Core.SerializeOptimizers
{
    internal class AsyncSerializeOptimizer
    {
        private readonly Task task;
        private readonly Thread thisThread;

        public AsyncSerializeOptimizer(Task task)
        {
            this.task = task;
            thisThread = new Thread(Run);
            thisThread.Start();
        }

        private void Run()
        {
            while (!task.IsCompleted)
            {
                GC.Collect();
                thisThread.Join(1000);
            }
        }
    }
}
