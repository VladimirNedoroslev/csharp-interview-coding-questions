// using System;
// using System.Xml;
//
// namespace ValueReferenceTask;
//
// file class Test3
// {
//     public void Start()
//     {
//         var x = 1;
//         IncrementIn(x);
//         Console.WriteLine(x);  // ?
//
//         x = 1;
//         IncrementOut(out x);
//         Console.WriteLine(x); // ?
//
//         x = 1;
//         IncrementRef(ref x);
//         Console.WriteLine(x);
//     }
//
//     private void IncrementRef(ref int x)
//     {
//         x++;
//     }
//
//     private static void IncrementOut(out int x)
//     {
//     x++;
//     }
//     
//     private static void IncrementIn(in int x)
//     {
//     x++;
//     }
// }