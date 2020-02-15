using System;
using System.Threading;

namespace TestConsol
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            ThreadTests.Start();
            Console.WriteLine("Приложение должно быть закрыто");
        }
        
    }
}
