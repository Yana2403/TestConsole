using System;
using System.Threading;

namespace TestConsol
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            //ThreadPoolTests.Start();
            //ThreadTests.Start();
            // SynchronizationTests.Start();
            TAP.Start();

            Console.ReadLine();
            Console.WriteLine("Приложение должно быть закрыто");
        }
        
    }
}
