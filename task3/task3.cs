using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

class task3
{

    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Invalid number of command line arguments");
            return;
        }

        string testsResultsJsonPath = args[0];
        string testsJsonPath = args[1];
        string reportJsonPath = args[2];

        try
        {
            string testsResultsJson = File.ReadAllText(testsResultsJsonPath);
            string testsJson = File.ReadAllText(testsJsonPath);

            TestsResults testsResults = JsonConvert.DeserializeObject<TestsResults>(testsResultsJson);
            Dictionary<int, string> testsResultsDict = testsResults.Values.ToDictionary(t => t.Id, t => t.Value);
            TestsData testsData = JsonConvert.DeserializeObject<TestsData>(testsJson);
            FillTestData(testsData.Tests, testsResultsDict);

            string reportJson = JsonConvert.SerializeObject(
                testsData,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
            File.WriteAllText(reportJsonPath, reportJson);

            Console.WriteLine("Report generated");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error during file handling occured: {ex.Message}");
        }
        catch (JsonReaderException ex)
        {
            Console.WriteLine($"An error during JSON parsing occured: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void FillTestData(List<Test> tests, Dictionary<int, string> results)
    {
        foreach (var test in tests)
        {
            if (results.TryGetValue(test.Id, out string result))
                test.Value = result;

            if (test.Values != null)
                FillTestData(test.Values, results);
        }
    }

    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public List<Test> Values { get; set; }
    }

    public class TestsData
    {
        public List<Test> Tests { get; set; }
    }

    public class TestResult
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }

    public class TestsResults
    {
        public List<TestResult> Values { get; set; }
    }
}

