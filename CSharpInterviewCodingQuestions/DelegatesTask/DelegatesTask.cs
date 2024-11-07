// ReSharper disable AccessToModifiedClosure

using System;
using System.Collections.Generic;

namespace DelegatesTask;

public static class DelegatesTask
{
    public static void Start()
    {
        const int n = 10;
        var actions = new List<Action>();

        for (var i = 0; i < n; i++)
        {
            actions.Add(() => Console.WriteLine(i));
        }

        foreach (var action in actions)
        {
            action();
        }
        // Output ?
    }
}