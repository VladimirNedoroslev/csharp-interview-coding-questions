using System;
using System.Collections.Generic;

namespace ValueReferenceTask;

public static class Test1
{
    public static void Start()
    {
        var list = new List<int>();
        var list2 = list;

        AddValue(list2);

        Console.WriteLine(list[0]); // ?
        Console.WriteLine(list2[0]); // ?
    }

    private static void AddValue(List<int> list)
    {
        list.Add(1);
    }
        
}