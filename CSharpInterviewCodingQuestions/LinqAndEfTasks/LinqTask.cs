namespace LinqAndEfTasks;

public static class LinqTask
{
    public static void Start()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };

        var evenNumbers = numbers.Where(x => x % 2 == 0);

        numbers.Add(6);

        foreach (var evenNumber in evenNumbers)
        {
            Console.WriteLine(evenNumber); // ?
        }
    }
}