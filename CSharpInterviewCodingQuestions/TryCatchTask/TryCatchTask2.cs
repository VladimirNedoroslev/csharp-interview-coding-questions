using System;

// ReSharper disable PossibleNullReferenceException
namespace TryCatchTask
{
    public static class TryCatchTask2
    {
        public static void Start()
        {
            try
            {
                Foo();
            }
            // how to catch each exception separately?
            catch
            {
                
            }
        }

        private static void Foo()
        {
            var random = new Random();
            var randomNumber = random.Next(0, 3);
            throw randomNumber switch
            {
                1 => new SystemException(),
                2 => new ApplicationException(),
                _ => null
            };
        }
    }
}