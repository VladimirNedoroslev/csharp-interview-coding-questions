using System;

namespace ValueReferenceTask;

public static class Test2
{
    public static void Start()
    {
        var x = 1;
        Increment(x);
        Console.WriteLine(x); // ?
            
        x = 1;
        IncrementRef(ref x);
        Console.WriteLine(x); // ?
    }

    private static void Increment(int x)
    {
        x++;
    }
        
    private static void IncrementRef(ref int x)
    {
        x++;
    }
}