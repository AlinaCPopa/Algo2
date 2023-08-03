using static System.Threading.Thread;

namespace ConcurrencyClassesExample
{
    internal class UnSyncResource
    {
        // Do not enforce synchronization.
        public void Access()
        {
            Console.WriteLine("Starting unsynchronized resource access on Thread #{0}",
                CurrentThread.ManagedThreadId);
            if (CurrentThread.ManagedThreadId % 2 == 0)
                Sleep(2000);

            Sleep(200);
            Console.WriteLine("Stopping unsynchronized resource access on thread #{0}",
                CurrentThread.ManagedThreadId);
        }
    }
}
