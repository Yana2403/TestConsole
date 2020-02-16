using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HomeWork5
{
    class Factorial
    { 
       public static void count_factorial(int number)
        {
            double res = 1;
            for (int i = 2; i <= number; i++)
            {
                res *= i;
            }
            Console.WriteLine(res);
            //Console.WriteLine("Факториал числа = ", res); -  не работает(?)

        }
        public static void count_summ(int number)
        {
            int value = 0;
            for (int i = 0;  i<= number; i++)
            {
                value += i;
            }
            Console.WriteLine(value);
        }
        public static void Start()
        {
            Console.WriteLine("Введите число");
            var number = Convert.ToInt32(Console.ReadLine());
            var factorial = new Thread(()=> count_factorial(number));
            factorial.Start();
            var summ = new Thread(()=>count_summ(number));
            summ.Start();
        }
}
    }
  
