namespace Task_Programming
{
    internal class Cancelling
    {
        public Cancelling()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            token.Register(() =>
            {
                Console.WriteLine("Cancellation has been requested.");
            });

            var t = new Task(() =>
            {
                int i = 0;
                while (true)
                {
                    /*
                    if (token.IsCancellationRequested)
                    {
                        // break; // Soft Exit
                        throw new OperationCanceledException();  // Recommended to use Exceptions
                    }
                    else  
                        Console.WriteLine($"{i++}\t");
                    */
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\t");
                }
            }, token);
            t.Start();

            Task.Factory.StartNew(() =>
            {
                token.WaitHandle.WaitOne();
                Console.WriteLine("Wait handle released, cancellation was requested");
            });

            Console.ReadKey();
            cts.Cancel();
        }
    }
}
