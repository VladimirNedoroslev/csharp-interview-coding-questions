namespace ThreadTask1;

public static class TaskTest1
{
    public static async Task Start()
    {
        var task = GetValueAsync1();
            
        // What is the difference?
        await task;
        // task.Result;
        task.GetAwaiter().GetResult();
        task.Wait();
        var result = await task;
        Console.WriteLine(result);
    }

    // Difference between these methods? 
    private static Task<int> GetValueAsync1()
    {
        Task.Delay(TimeSpan.FromSeconds(1));
            
        return Task.FromResult(10);
    }
        
    private static async Task<int> GetValueAsync2()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        return 10;
    }
}