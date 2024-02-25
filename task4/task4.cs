class task4
{
    static int Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Not enough arguments");
            return 1;
        }
        String pathToList = args[0].Replace('\\', '/');
        int[] list = Array.ConvertAll(File.ReadAllLines(pathToList), int.Parse);
        Array.Sort(list);
        int median;
        int middleIndex = list.Length / 2;
        if (list.Length % 2 == 1)
            median = list[middleIndex];
        else
            median = (list[middleIndex - 1] + list[middleIndex]) / 2;
        int steps = 0;
        foreach (int i in list)
        {
            steps += Math.Abs(median - i);
        }
        Console.WriteLine(steps);
        return 0;
    }
}