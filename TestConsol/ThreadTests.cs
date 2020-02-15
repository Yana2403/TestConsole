using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestConsol
{
    internal static class ThreadTests
    {
        private static void CheckThread(Thread thread)
        {
            Console.WriteLine("Поток[id: {0}]:{1} - {2}фоновый", thread.ManagedThreadId, thread.Name, thread.IsBackground ? "" : "не ");
        }
        public static void Start()
        {
            Thread.CurrentThread.Name = "Главный поток";
            CheckThread(Thread.CurrentThread);

            var clock_thread = new Thread(ClockThread); ///создание нового потока
            clock_thread.Name = "Фоновый поток";
            //создание фонового потока
            clock_thread.Priority = ThreadPriority.BelowNormal;
            // clock_thread.IsBackground = true; //чтобы не блокировал главный поток
            clock_thread.Start(); //для запуска потокa

            var message = "Hello world!";
            var printer1_thread = new Thread(PrinterThread); //1 вариант передачи сообщения в поток
            printer1_thread.Start(message);

            var printer2_thread = new Thread(() => PrinterThread(message)); //2 вариант через лямбду выражений 
            printer2_thread.Start();


            Console.WriteLine("Главный поток завершен");
            Console.ReadLine();

            //_ClockCanWork = false;

            if (!clock_thread.Join(100)) //для корректного завершения потока
                clock_thread.Interrupt(); //прерывает поток в тех местах где спит
                                          // clock_thread.Abort(); //прерывает в любом месте поток


        }
        private static bool _ClockCanWork = true;
        private static void ClockThread() //метод для запуска потока
        {//обновляет данные- вывод часы в заголовок окна
            try
            {
                CheckThread(Thread.CurrentThread);

                while (_ClockCanWork)
                {
                    Console.Title = DateTime.Now.ToString();
                    Thread.Sleep(100);
                }

            }

            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Поток был прерван");
            }
            Console.WriteLine("Поток часов завершился");
        }
        private static void PrinterThread(object parameter)
        {
            PrinterThread((string)parameter);
        }
        private static void PrinterThread(string Message)
        {
            Console.WriteLine("Печать сообщени из потока id {0} - {1} ", Thread.CurrentThread.ManagedThreadId, Message);
            Thread.Sleep(2000);
            Console.WriteLine("Печать сообщени из потока id  {0} - {1} - завершена", Thread.CurrentThread.ManagedThreadId, Message);
        }
    }
}
