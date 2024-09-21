namespace Task_Programming
{
    internal class WaitingOnTasks
    {
        public WaitingOnTasks()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var t = new Task(() =>
            {
                Console.WriteLine("I take 5 seconds");

                for (int i = 0; i < 5; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }

                Console.WriteLine("Task complete.");
            }, token);
            t.Start();

            // Console.ReadKey();
            // cts.Cancel(); // Will throw an exception which is not handled...

            Task t2 = Task.Factory.StartNew(() => Thread.Sleep(3000), token);

            // t.Wait(token);
            Task.WaitAll(new[] { t, t2 }, 4000, token);
            // Task.WaitAny();

            Console.WriteLine($"Task t status is {t.Status}");
            Console.WriteLine($"Task t2 status is {t2.Status}");
        }
    }
}
