using System.Threading.Tasks;

namespace ThreadTask1
{
    class Program
    {
        private static async Task Main()
        {
             await TaskTest1.Start();
        }
    }
}