using System;
using System.Collections.Generic;

namespace ValueReferenceTask;

public static class Test4
{
    public static void Start()
    {
        var list = new List<int> {1, 2, 3, 4, 5};
        ChangeList(list);
        foreach (var number in list)
        {
            Console.WriteLine(number); // ?
        }
    }

        
    // Difference between these methods? 
        
    private static void ChangeList(List<int> list)
    {
        list = new List<int> {6, 7, 8};
    }

    private static void ChangeListRef(ref List<int> list)
    {
        list = new List<int>();
    }
}