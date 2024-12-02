Console.WriteLine("01 - Historian Histeria");

string inputPath = "../../../input.csv";
int distance = 0;
using (StreamReader sr = new StreamReader(inputPath))
{
    List<int> list1 = new List<int>();
    List<int> list2 = new List<int>();

    while (!sr.EndOfStream)
    {
        string? line = await sr.ReadLineAsync();
        string[] splitted = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        int a = int.Parse(splitted[0]);
        int b = int.Parse(splitted[1]);
        list1.Add(a);
        list2.Add(b);
    }

    IEnumerable<int> sorted1 = list1.Order();
    IEnumerable<int> sorted2 = list2.Order();

    for(int i = 0; i < sorted1.Count(); i++)
    {
        distance += Math.Abs(sorted1.ElementAt(i) - sorted2.ElementAt(i));
    }
}

Console.WriteLine($"Distance = {distance}");