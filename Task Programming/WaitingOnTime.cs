namespace Task_Programming
{
    internal class WaitingOnTime
    {
        public WaitingOnTime()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var t = new Task(() =>
            {
                // Thread.Sleep();
                // Thread.SpinWait();
                //  SpinWait.SpinUntil();

                Console.WriteLine("Press any key to disarm; you have 5 seconds");
                bool cancelled = token.WaitHandle.WaitOne(5000);

                Console.WriteLine(cancelled ? "Bomb disarmed" : "boom");
            }, token);
            t.Start();

            Console.ReadKey();
            cts.Cancel();
        }
    }
}
