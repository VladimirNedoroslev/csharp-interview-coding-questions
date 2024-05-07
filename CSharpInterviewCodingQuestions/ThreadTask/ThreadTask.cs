using System;
using System.Threading;

namespace ThreadTask1
{
    public static class ThreadTask
    {
        private static int _x;

        public static void Start()
        {
            var thread = new Thread(Foo);
            thread.Start();
            for (var i = 0; i < 100000; i++)
            {
                _x++;
                Console.WriteLine(_x); 
            }

            // Output ?
            thread.Join();
            Console.WriteLine(_x); // ?
        }

        private static void Foo(object? obj)
        {
            for (var i = 0; i < 100000; i++)
            {
                _x++;
            }
        }
    }
}