using System.Diagnostics;
using static System.Console;
using static System.Math;

namespace CourseL4
{
    class Program
    {
        static readonly Random rand = new();
        static void Main()
        {
            //Ex1_L4();
            //Ex2_L4();
            //Ex3_L4();
            //Ex4_L4();
            //Ex5_L4();
            //Ex6_L4();
            //Ex7_L4();
            //Ex8_L4();
            //Ex9_L4();
            //Ex10_L4();
            //Ex11_forL3();
            //Ex12_forL3();
            Ex13_forL3();
        }
        private static void Ex1_L4()
        {
            int i = 1;
            while (i <= 5) { WriteLine(i++); }
            i = 1;
            do
                WriteLine(i++);
            while (i <= 5);

            for (i = 1; i <= 5;)
                WriteLine(i++);
        }
        private static void Ex2_L4()
        {
            for (int i = 0; i <= 10; i++)
            {
                WriteLine($"3 * {i} = {3 * i}");
            }
        }
        private static void Ex3_L4()
        {
            //для цього краще юзати масиви, але обійдемся без них поки
            int tmp;
            WriteLine("this numbers is evenly divisble on 3 & isn't by 5:");
            for (int i = 0; i < 100; i++)
            {
                tmp = rand.Next(20, 50);
                if (tmp % 3 == 0 && tmp % 5 != 0)
                    WriteLine(tmp);
            }
        }
        private static void Ex4_L4()
        {
            WriteLine("We are bank)\nPlz enter sum:");
            var sum = double.Parse(ReadLine());
            WriteLine("Enter time in years:");
            var time = double.Parse(ReadLine());
            WriteLine("Enter percent:");
            var percent = double.Parse(ReadLine());
            var result = sum;
            // зрозуміло що там є 1 формула і без циклу але заюзаю for
            Write($"Process:\n{sum}");
            for (int i = 0; i < time; i++)
            {
                result += sum * (percent / 100);
                sum = result;
                Write($"=>{Round(sum, 3)}");
            }
            WriteLine("\nResult is:{0}", Round(sum, 3));
        }
        private static void Ex5_L4()
        {
            WriteLine("Enter any num >= 1");
            int num = int.Parse(ReadLine()), sum = num;
            if (num > 0)
            {
                for (int i = num; i > 0; i--)
                    sum += --num;
                WriteLine($"sum of [1;n]: {sum}");
            }
            else
                WriteLine("num isn't >=1");
        }
        private static void Ex6_L4()
        {
            int m = rand.Next(10, 100), startM = m, k = rand.Next(3, 20), i = 0;
            for (; m > 0 && m >= k; i++)
                m -= k;
            WriteLine($"Initial Petrik money: {startM}\nIcecream cost: {k}\nIcecream total num: {i}\nRemainder: {m}");
        }
        private static void Ex7_L4()
        {
            int m = rand.Next(3, 11), k = rand.Next(5, 10);
            WriteLine($"k = {k}, m = {m}");
            for (int i = 0; i < m; i++, WriteLine())
                for (int j = 0; j < k; j++)
                    Write((j == 0 || j == k - 1 || i == 0 || i == m - 1) ? "*" : " ");
            /*while (true)
            {
                int m = rand.Next(10, 20), k = rand.Next(5, 30);
                for (int i = 0; i < m; i++, WriteLine())
                    for (int j = 0; j < k; j++)
                        Write((j == 0 || j == k - 1 || i == 0 || i == m - 1) ? "*" : " ");
                Thread.Sleep(100);
                Clear();
            }*/
        }
        private static void Ex8_L4()
        {
            Write("Enter num of Fibo presenting: ");
            int fiboNum = int.Parse(ReadLine());
            long a = 0, b = 1, tmp;
            WriteLine("Fibo row: ");
            if (fiboNum > 0)
                for (int i = 0; i < fiboNum; i++)
                {
                    if (i == 0) { Write(0); continue; }
                    tmp = a + b;
                    b = a;
                    Write($" {a = tmp}");
                }
            else
                WriteLine("num isn't > 0");

            /*var st = new Stopwatch();
            st.Start();
            if (fiboNum > 0)
                for (int i = 0; i < fiboNum; i++)
                {
                    if (i == 0) { Write(0); continue; }
                    tmp = a + b;
                    b = a;
                    //Write($" {a = tmp}");
                }
            else { }
            //WriteLine("num isn't > 0");
            WriteLine($"\n{st.ElapsedMilliseconds}");*/
        }
        private static void Ex9_L4()
        {
            Write("Enter a: ");
            int a = int.Parse(ReadLine());
            Write("Enter b: ");
            int b = int.Parse(ReadLine());
            if (a > b)
            {
                WriteLine("a>b");
                for (int i = b + 1; i < a; i++)
                    Write($" {i}");
            }
            if (b > a)
            {
                WriteLine("a>b");
                for (int i = a + 1; i < b; i++)
                    Write($" {((i % 2 == 1) ? i : "")}");
            }
        }
        private static void Ex10_L4()
        {
            string _a, _b;
            double a, b;
            bool end = false;
            while (end != true)
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
            Start:
                WriteLine("Enter any operation (+ - * / % pow or 0 for exit):");
                string sign = ReadLine();
                switch (sign)
                {
                    case "0": end = true; break;
                    case "+": WriteLine($"{a}+{b}={Round(a + b, 3)}"); break;
                    case "-": WriteLine($"{a}-{b}={Round(a - b, 3)}"); break;
                    case "*": WriteLine($"{a}*{b}={Round(a * b, 3)}"); break;
                    case "/": WriteLine($"{a}/{b}={Round(a / b, 3)}"); break;
                    case "%": WriteLine($"{a}%{b}={Round(a % b, 3)}"); break;
                    case "pow": WriteLine($"{a}^{b}={Round(Pow(a, b), 3)}"); break; //...
                    default:
                        WriteLine("Operation unfound. Plz enter else sign from existing:\n" +
                            "+ - * / % pow or 0 for exit");
                        goto Start;
                }
            }
        }
        private static void Ex11_forL3()
        {
            string _x;
            double x, y;
            while (true)
            {
                Write("Enter x: ");
                _x = ReadLine();
                if (double.TryParse(_x, out x))
                    break;
                WriteLine("x wasn't parsed. Plz enter again");
            }
            if (x <= -20)
                y = Round(3 * Pow(x, 3));
            else
                y = (x > -20 && x <= 30) ? Abs(x) : 30;
            WriteLine($"y = {y}");
        }
        private static void Ex12_forL3()
        {
            string _r, _a;
            double r, a;
            bool end = false;
            while (true)
            {
                Write("Enter radius of circle: ");
                _r = ReadLine();
                Write("Enter side of square: ");
                _a = ReadLine();
                if (double.TryParse(_r, out r) && double.TryParse(_a, out a))
                    break;
                WriteLine("radius or side wasn't parsed. Plz enter again");
            }
            WriteLine("Area of cicle {0} area of square", (PI * r * r) > (a * a) ? ">" : "<");
        }
        private static void Ex13_forL3()
        {
            string _angle;
            double angle, y;
            while (true)
            {
                Write("Enter angle: ");
                _angle = ReadLine();
                if (double.TryParse(_angle, out angle))
                    break;
                WriteLine("angle wasn't parsed. Plz enter again");
            }
            if (angle >= 0 && angle <= 180)
                switch (angle)
                {
                    case < 90: WriteLine($"Angle {angle}° is acute"); break;
                    case < 91: WriteLine($"Angle {angle}° is right"); break;
                    case < 180: WriteLine($"Angle {angle}° is obtuse"); break;
                    case < 181: WriteLine($"Angle {angle}° is straight"); break;
                    default: break;
                }
        }
    }
}