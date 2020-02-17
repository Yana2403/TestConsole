using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsol
{
    class TAP
    {
        public static void Start()
        {
            //new Thread(() => { Console.WriteLine("печать внутри потока"); }) { IsBackground = true }.Start();
            /*  Action<string> printer = str => Console.WriteLine("Печать сообщения из потока {0}:{1}", Thread.CurrentThread.ManagedThreadId, str);
              printer("Message 1");
              printer.Invoke("Message 2");
              IAsyncResult result = null;
              result = printer.BeginInvoke("Message 3", r => printer.EndInvoke(result), null);*/

            //использование подхода основанного на событиях
            /* BackgroundWorker worker = new BackgroundWorker();
             worker.DoWork += (s, e) => { /*здесь выполняется сама асинхронная опреация};
             worker.ProgressChanged += (s, e) => { действия по изменению UI при изменении прогресса операции};
             worker.RunWorkerCompleted -при завершении операции */

            //var messages = Enumerable.Range(1, 100).Select(i => ($"Messages {i:000}").ToCharArray());

            /* Parallel.Invoke(
                 new ParallelOptions { MaxDegreeOfParallelism = 2 },//максимальное количество параллельных потоков
                 ParallelInvokeMethod,
                 ParallelInvokeMethod,
                 ParallelInvokeMethod,
                 () => Console.WriteLine("Еще один параллельный вызов")) ;//выполнение параллельного потока*/

            Parallel.Invoke(
                new ParallelOptions { MaxDegreeOfParallelism = 2 },//максимальное количество параллельных потоков
                Enumerable.Repeat(new Action(ParallelInvokeMethod), 100).ToArray());//выполнение параллельного потока



            Console.WriteLine("Главный поток завершился");
            Console.ReadLine();
            Console.WriteLine("Приложение должно быть закрыто");
        }
        private static void ParallelInvokeMethod()
        {
            Console.WriteLine("ThrID:{0} - started", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(250);
            Console.WriteLine("ThrID:{0} - finished", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
