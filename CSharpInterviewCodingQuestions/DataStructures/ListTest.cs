using System;
using System.Collections.Generic;

namespace DataStructures;

public static class ListTest
{
    public static void Start() // Time/Memory complexity ?
    {
        const int n = 100;
        var list = new List<int>();
        for (var i = 0; i < n; i++) // Time complexity ?
        {
            list.Add(i); // Time complexity ? 
        }

        var random = new Random();
        for (var i = 0; i < n; i++) // Time complexity ? 
        {
            var randomNumber = random.Next(0, n);
            list.Find(x => x == randomNumber); // Time complexity ? 
        }

        list.Add(-1); // Time Complexity ?
        list.Remove(-1); // Time complexity ?

        const int dummyValue = -1;
        for (var i = 0; i < n; i++) // TimeComplexity ?
        {
            var randomIndex = random.Next(0, list.Count);
            list.Insert(randomIndex, dummyValue); // Time complexity ?
        }
    }
}