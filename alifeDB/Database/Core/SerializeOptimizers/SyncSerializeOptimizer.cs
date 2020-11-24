using System;
using System.Threading;

namespace alifeDB.Database.Core.SerializeOptimizers
{
    internal class SyncSerializeOptimizer
    {
        private readonly Thread thread;

        public SyncSerializeOptimizer()
        {
            thread = new Thread(Run);
            thread.Start();
        }

        private void Run()
        {
            while (true)
            {
                GC.Collect();
                thread.Join(1000);
            }
        }

        internal void Stop()
        {
            thread.Abort();
        }
    }
}
