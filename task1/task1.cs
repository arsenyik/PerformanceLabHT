class task1
{
    static int Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Invalid number of command line arguments");
            return 1;
        }

        int arrMaxValue = int.Parse(args[0]);
        var arrStep = int.Parse(args[1]);

        if (arrMaxValue <= 0 || arrStep <= 0)
        {
            Console.WriteLine("Invalid values");
            return 1;
        }

        string result = String.Empty;
        int arrCureentValue = 1;

        do
        {
            result += arrCureentValue.ToString();
            arrCureentValue = (arrCureentValue - 2 + arrStep) % arrMaxValue + 1;
        } while (arrCureentValue != 1);
        Console.WriteLine(result);
        return 0;
    }
}
