class task2
{
    static int Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Not enough arguments");
            return 1;
        }
        String circle = args[0].Replace('\\', '/');
        String points = args[1].Replace('\\', '/');
        string[] center = File.ReadAllLines(circle);
        string[] coords0 = center[0].Split(' ');
        double x0 = Double.Parse(coords0[0]);
        double y0 = Double.Parse(coords0[1]);
        double radiusSquared = Math.Pow(Double.Parse(center[1]), 2);

        using StreamReader sr = new StreamReader(points);
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] point = line.Split(' ');
            double x1 = Double.Parse(point[0]);
            double y1 = Double.Parse(point[1]);
            Console.WriteLine(PointChecker(radiusSquared, x0, y0, x1, y1));
        }
        return 0;
    }

    static int PointChecker(double r0Sqr, double x0, double y0, double x1, double y1)
    {
        double r1Sqr = Math.Pow(x1 - x0, 2) + Math.Pow(y1 - y0, 2);

        if (r0Sqr > r1Sqr)
            return 1;
        if (r0Sqr == r1Sqr)
            return 0;
        return 2;
    }
}