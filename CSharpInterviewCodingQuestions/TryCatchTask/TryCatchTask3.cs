using System;

namespace TryCatchTask
{
    public static class TryCatchTask3
    {
        public static void Start()
        {
            // Output ?
            try
            {
                Foo();
            }
            finally
            {
                Console.WriteLine("Finally!");
            }
        }

        private static void Foo()
        {
            Foo();
        }
    }
}