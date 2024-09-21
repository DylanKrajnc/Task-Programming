namespace Task_Programming
{
    internal class HandlingTaskExceptions
    {
        public HandlingTaskExceptions()
        {
            try
            {
                Test();
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    Console.WriteLine($"Exception {e.GetType()} from {e.Source}");
                }
            }
        }

        public static void Test()
        {
            var t = new Task(() =>
            {
                throw new InvalidOperationException("Can't do this!") { Source = "t" };
            });

            var t2 = new Task(() =>
            {
                throw new AccessViolationException("Can't access this!") { Source = "t2" };
            });

            t.Start();
            t2.Start();

            try
            {
                Task.WaitAll(t, t2);
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    if (e is InvalidOperationException)
                    {
                        Console.WriteLine("Invalid op!");
                        return true;
                    }
                    return false;
                });
            }
        }
    }
}
