class Program
{
    private static int CAPACITY = 12;
    private static int currentCapacity = 0;
    private static int redCount = 0; // 1
    private static int greenCount = 0; // 2
    private static int yellowCount = 0; // 3
    static void Add(int ball)
    {
        if(ball == 1 && redCount+1 > greenCount)
        {
            Console.WriteLine("Not allowed for red ball");
            return;
        } else if(ball == 3 && (yellowCount > 0.4 * currentCapacity))
        {
            Console.WriteLine("Not allowed for yellow ball");
            return;
        }

        if (ball == 1) redCount++;
        else if (ball == 2) greenCount++;

        currentCapacity++;
        Console.WriteLine($"Total Current Capacity: {currentCapacity}");
    }
    public static void Main(string[] args)
    {
        int totalCapacity = 12;
        Add(1);
        Add(2);
        Add(1);
    }
}