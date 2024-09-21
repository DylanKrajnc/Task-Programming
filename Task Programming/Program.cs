using Task_Programming;

internal static class Program
{
    public static void Main()
    {
        // CreationStart cs = new CreationStart();
        // Cancelling c = new Cancelling();
        // CompositeCancellationTokens cct = new CompositeCancellationTokens();
        WaitingOnTime w = new WaitingOnTime();

        Console.WriteLine("Main program done.");
        Console.ReadKey();
    }
}
