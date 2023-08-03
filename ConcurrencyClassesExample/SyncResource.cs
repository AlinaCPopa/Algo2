using static System.Threading.Thread;

namespace ConcurrencyClassesExample
{
    internal class SyncResource
    {
        // Use a monitor to enforce synchronization.
        public void Access()
        {
            lock (this)
            {
                Console.WriteLine("Starting synchronized resource access on thread #{0}",
                    CurrentThread.ManagedThreadId);
                if (CurrentThread.ManagedThreadId % 2 == 0)
                    Sleep(2000);

                Sleep(200);
                Console.WriteLine("Stopping synchronized resource access on thread #{0}",
                    CurrentThread.ManagedThreadId);
            }
        }
    }
}
