// Example from https://learn.microsoft.com/en-us/dotnet/api/system.threading.monitor?view=net-7.0

namespace ConcurrencyClassesExample;

class Program
{
    public static void Main()
    {
        var numOps = 5;
        var opsAreDone = new AutoResetEvent(false);
        var syncRes = new SyncResource();
        var unSyncRes = new UnSyncResource();

        void SyncUpdateResource(Object state)
        {
            // Call the internal synchronized method.
            syncRes.Access();

            // Ensure that only one thread can decrement the counter at a time.
            if (Interlocked.Decrement(ref numOps) == 0)
                // Announce to Main that in fact all thread calls are done.
                opsAreDone.Set();
        }

        void UnSyncUpdateResource(Object state)
        {
            // Call the unsynchronized method.
            unSyncRes.Access();

            // Ensure that only one thread can decrement the counter at a time.
            if (Interlocked.Decrement(ref numOps) == 0)
                // Announce to Main that in fact all thread calls are done.
                opsAreDone.Set();
        }




        // Set the number of synchronized calls.
        for (var i = 0; i <= 4; i++)
            ThreadPool.QueueUserWorkItem(SyncUpdateResource);

        // Wait until this WaitHandle is signaled.
        opsAreDone.WaitOne();
        Console.WriteLine("\t\nAll synchronized operations have completed.\n");

        // Reset the count for unsynchronized calls.
        numOps = 5;
        for (var i = 0; i <= 4; i++)
            ThreadPool.QueueUserWorkItem(UnSyncUpdateResource);

        // Wait until this WaitHandle is signaled.
        opsAreDone.WaitOne();
        Console.WriteLine("\t\nAll unsynchronized thread operations have completed.\n");

    }

}




