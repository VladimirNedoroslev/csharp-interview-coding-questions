using System;

namespace TryCatchTask
{
    public static class TryCatchTask1
    {
        public static void Start()
        {
            Foo();
            // Process any exception here
        }

        private static void Foo()
        {
            try
            {
                Job();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void Job() => throw null;
    }
}