#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
namespace ThreadTask1;

public static class TaskTest2
{
    public static async Task Start()
    {
        await SomeWorkAsync_1();
    }

    private static async Task SomeWorkAsync_1()
    {
        SomeWorkAsync_2();
        Console.WriteLine("Work 1 has been done");
        await SomeWorkAsync_3();
    }


    private static async Task SomeWorkAsync_2()
    {
        await SomeWorkAsync_3();
        Console.WriteLine("Work 2 has been done");
    }


    private static async Task SomeWorkAsync_3()
    {
        await Task.Delay(500);
        Console.WriteLine("Work 3 has been done");
    }
}