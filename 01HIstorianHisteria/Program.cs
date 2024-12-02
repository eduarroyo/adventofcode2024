Console.WriteLine("01 - Historian Histeria");


string inputPath = "../../../input.csv";
int distance = 0;
int similarity = 0;

(List<int> list1, List<int> list2) = await ReadInput(inputPath);

distance = Distance(list1, list2);
similarity = Similarity(list1, list2);


Console.WriteLine($"Distance = {distance}");
Console.WriteLine($"Similarity = {similarity}");

static async Task<(List<int>, List<int>)> ReadInput(string inputPath)
{
    List<int> list1 = [], list2 = [];
    using (StreamReader sr = new StreamReader(inputPath))
    {
        while (!sr.EndOfStream)
        {
            string? line = await sr.ReadLineAsync();
            string[] splitted = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int a = int.Parse(splitted[0]);
            int b = int.Parse(splitted[1]);
            list1.Add(a);
            list2.Add(b);
        }
    }
    return (list1, list2);
}

static int Distance(List<int> list1, List<int> list2)
{
    IEnumerable<int> sorted1 = list1.Order();
    IEnumerable<int> sorted2 = list2.Order();
    int distance = 0;

    for (int i = 0; i < sorted1.Count(); i++)
    {
        distance += Math.Abs(sorted1.ElementAt(i) - sorted2.ElementAt(i));
    }

    return distance;
}

static int Similarity(List<int> list1, List<int> list2)
{
    int similarity = 0;

    foreach(int i in list1)
    {
        similarity += i * list2.Count(n => n == i);
    }

    return similarity;
}