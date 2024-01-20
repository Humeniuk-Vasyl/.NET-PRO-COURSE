using System;
using static System.Console;
using static System.Math;

namespace CourseL16
{
    public class Program
    {
        static Random rnd = new();

        public static void Main()
        {
            /*//Ex1
            MyDelegateClass.MyDelegate myDelegateEx = (a, b, c) => Round((double)(a + b + c) / 3, 3);
            WriteLine($"res -> {myDelegateEx(2, 3, 9)}");
            */

            //Ex2
            //MyOps.Ex2Test();

            //Ex3_L16
            Ex3(new Func<double, double>[10]);
        }
        public static void Ex3(Func<double, double>[] delegates)
        {
            List<double> items = new();
            int length = delegates.Length;
            WriteLine("Average of delegates that contain method with rnd nums =>");
            for (int i = 0; i < length; i++)
            {
                delegates[i] = a => a;
                items.Add(delegates[i](rnd.Next(10, 100)));
                Write(!(i==length-1)?$"{items[i]} + " : $"{ items[i]} ");
            }
            WriteLine($"= {Round(items.Average(), 3)}");
        }
    }

    //Ex1_L16
    public class MyDelegateClass
    {
        public delegate double MyDelegate(int arg1, int arg2, int arg3);
    }

    //Ex2_L16
    public class MyOps
    {
        //Op lyamda operations
        private static readonly Func<double, double, double> add = (a, b) => a + b;
        private static readonly Func<double, double, double> sub = (a, b) => a - b;
        private static readonly Func<double, double, double> mult = (a, b) => a * b;
        private static readonly Func<double, double, double> div = (a, b) => a / b;

        public static void Ex2Test()
        {
            bool end = false;
            double a = 0, b = 0;
            string? op = "", _a, _b;
            while (!end)
            {
                while (true)
                {
                    Write("Enter a: ");
                    _a = ReadLine();
                    Write("Enter b: ");
                    _b = ReadLine();
                    if (double.TryParse(_a, out a) && double.TryParse(_b, out b))
                        break;
                    WriteLine("a or b wasn't parsed. Plz enter again");
                }
                WriteLine("Choose operation: +, -, *, / or 0 for exit.");

            OpSelector:
                op = ReadLine();
                switch (op)
                {
                    case "0": end = true; break;
                    case "+": WriteLine($"add res -> {add(a, b)}"); break;
                    case "-": WriteLine($"sub res -> {sub(a, b)}"); break;
                    case "*": WriteLine($"mult res -> {mult(a, b)}"); break;
                    case "/": WriteLine((b == 0) ? "Can't divide by 0!" : $"div res -> {div(a, b)}"); break;
                    default:
                        WriteLine("Operation unfound. Plz enter else sign from existing:\n" +
                            "+ - * / or 0 for exit.");
                        goto OpSelector;
                }
            }
        }
    }
}