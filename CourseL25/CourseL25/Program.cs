using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
namespace CourseL25
{
    public delegate string MyDelegate(string s);
    public class Program
    {
        public static void Main()
        {
            //Ex1:
            //Ex1.Ex1_Test();

            //Ex2
            //new Ex2().Ex2_Test();

            //Ex3
            Ex3.Ex3_Test();

            ReadKey();
        }
    }

    #region Ex1_L25
    public class Ex1
    {
        public string Ex1_Method(string str)
        {
            Thread.Sleep(2000);
            return new string(str.Reverse().ToArray());
        }

        public void Callback(IAsyncResult ar)
        {
            var myDel = (MyDelegate)ar.AsyncState;
            var res = myDel.EndInvoke(ar);
            WriteLine($"Delegate is finished! Thread id: {Thread.CurrentThread.ManagedThreadId}\n" +
            $"myDel IAsyncResult AsyncState result: {res}\n\n" +
            "Async call is finished!");
        }

        public static void Ex1_Test()
        {
            WriteLine($"main Thread id {Thread.CurrentThread.ManagedThreadId}");

            Ex1 ex1 = new Ex1();
            var inDel = new MyDelegate(ex1.Ex1_Method);
            var asyncRes = inDel.BeginInvoke("Ex1", new AsyncCallback(ex1.Callback), inDel);

            //var asyncRes = inDel.Invoke("Ex1"); // варіант без обробки Callback

            //var res = inDel.EndInvoke(asyncRes); // варіант без обробки Callback,
            //проте важливо не запускати endInvoke двічі

            WriteLine("We already in main thread\n");

            //asyncRes.AsyncWaitHandle.WaitOne(); // без цього головний потік
            //не чекатиме завершення іншого потоку
            Thread.Sleep(1000);
            //WriteLine(asyncRes);
            ReadKey(); // в даному варіанті, оскільки ми запускаємо операції асинхронно
                       // після повернення до головного потоку без
                       // readKey() / readLine() програма одразу завершиться,
                       // не чекаючи поки завершиться синхронний потік
        }
    }
    #endregion

    #region Ex2_L25
    public class Ex2
    {
        static Random rnd = new Random();
        public void Ex2_Test()
        {
            int[] myArr;
            lock (this)
            {
                myArr = new int[10000000].Select(e => e = rnd.Next(1, 1000000)).ToArray();
            }

            Stopwatch st = new Stopwatch();
            st.Start();
            lock (this)
            {
                var res1 = myArr.AsParallel().Where(e => e % 2 != 0).ToArray();
            }

            WriteLine(st.ElapsedMilliseconds); // 146, 157, 149

            st.Restart();
            lock (this)
            {
                var res2 = myArr.Where(e => e % 2 != 0).ToArray();
            }
            WriteLine(st.ElapsedMilliseconds); //200, 178, 196 очевидно швидше ~15-30%

            /*foreach (var item in myArr)
            {
                WriteLine(item);
                Thread.Sleep(10); 
            }*/
        }
    }
    #endregion

    #region Ex3_L25
public static class Ex3
    {
        public static void Ex3_Print1()
        {
            WriteLine("First method thread id: " + Thread.CurrentThread.ManagedThreadId);

            WriteLine("\nEx3 method 1 starts:\n");
            for (int i = 0; i <= 50; i++)
            {
                Write($"(1): {i} ");
                Thread.Sleep(5);
            }
            WriteLine("\nEx3 method 1 ends!\n");
        }

        public static void Ex3_Print2()
        {
            WriteLine("Second method thread id: " + Thread.CurrentThread.ManagedThreadId);

            WriteLine("\nEx3 method 2 starts:\n");
            for (int i = 0; i <= 100; i++)
            {
                Write($"(2): {i} ");
                Thread.Sleep(5);
            }
            WriteLine("\nEx3 method 2 ends!\n");
        }

        public static void Ex3_Test()
        {
            WriteLine("Main id: " + Thread.CurrentThread.ManagedThreadId);
            WriteLine("Main thread start:"); // це не зовсім правильно,
            // але я хотів вивести тест в окремий метод
            
            /*var del1 = new Action(Ex3_Print1);
            var del2 = new Action(Ex3_Print2);
            Parallel.Invoke(
                del1,
                del2
                );*/

            //or:
            Parallel.Invoke(
            () => Ex3_Print1(),
            () => Ex3_Print2()
            );

            WriteLine("Main thread ends!"); // до цього доходимо лиш тоді,
                                            // коли обидва потоки з методами закінчені
            //Thread.Sleep(5000);
        }
    }
    #endregion
}