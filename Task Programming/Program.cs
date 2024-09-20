internal static class Program
{
    public static void Write(char c)
    {
        int i = 1000;
        while (i-- > 0)
        {
            Console.Write(c);
        }
    }

    public static void Write(object o)
    {
        int i = 1000;
        while (i-- > 0)
        {
            Console.Write(o);
        }
    }

    public static int TextLength(object o)
    {
        Console.WriteLine($"\nTask with id {Task.CurrentId} processing object {o}...");
        return o.ToString().Length;
    }

    public static void Main()
    {
        /*
        Task.Factory.StartNew(() => Write('1'));

        var t = new Task(() => Write('2'));
        t.Start();

        var t2 = new Task(Write, '3');
        t2.Start();

        Write('4');
        */

        string text1 = "testing", text2 = "this";
        var task1 = new Task<int>(TextLength, text1);
        task1.Start();
        var task2 = new Task<int>(TextLength, text2);
        task2.Start();

        Console.WriteLine($"Length of {text1} is {task1.Result}");
        Console.WriteLine($"Length of {text2} is {task2.Result}");

        Console.WriteLine("Main program done.");
        Console.ReadKey();
    }
}
