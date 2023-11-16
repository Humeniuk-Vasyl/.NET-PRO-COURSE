using System.Text;
using static System.Console;

namespace Course_L3
{
    class Program
    {
        static Random rand = new();
        public static void Main()
        {
            //Ex1_L3();
            //Ex2_L3();
            //Ex3_L3();
            //Ex4_L3();
            //Ex5_L3();
            //Ex6_L3();
            //Ex7_L3();
            //Ex8_L3();
            //Ex9_L3();
            //Ex10_L3();
            //Ex11_forL2();
            //Ex12_forL2();
            Ex13_forL2();
        }
        private static void Ex1_L3()
        {
            Write("Enter any num:");
            var a = Convert.ToInt32(ReadLine());
            WriteLine($"a({a})<10: {a < 10}");
            // Або так
            //WriteLine((Convert.ToInt32(ReadLine()) < 10) ? "True" : "False");

            // Або так)
            /*
            if (a < 10)
                WriteLine("a<10 \tTrue");
            else if (a > 10)
                WriteLine("a>10 \tFalse");
            else
                WriteLine("a == 10 \tEqual");*/
        }
        private static void Ex2_L3()
        {
            Write("Enter price: ");
            double price = double.Parse(ReadLine());
            Write("Enter num of good: ");

            double num = double.Parse(ReadLine());
            if (price > 0 && num > 0)
            {
                if (num > 0 && num < 3)
                    SameOutput(price, num, 0);
                else if (num == 3) // мабуть це малося на увазі в завданні 
                    SameOutput(price, num, 0.1);
                else if (num > 3 && num <= 7)
                    SameOutput(price, num, 0.2);
                else
                    SameOutput(price, num, 0.25);
            }
            else
                WriteLine("price or num can't be <= 0");
        }
        private static void SameOutput(double price, double num, double sale) =>
            WriteLine($"Full price: {price * num}, sale: {price * num * sale}. Price to pay: {price * num - price * num * sale}");
        private static void Ex3_L3()
        {
            Write("Enter num between 0 & 59: ");
            var min = Convert.ToInt32(ReadLine());

            if (min >= 0 && min < 16)
                WriteLine("Min in first quarter");
            else if (min >= 16 && min < 31)
                WriteLine("Min in second quarter");
            else if (min >= 31 && min < 46)
                WriteLine("Min in third quarter");
            else if (min >= 46 && min <= 60)
                WriteLine("Min in fourth quarter");
            else WriteLine("Min isn't between 0 & 59");

            /*if (min >= 0 && min <= 59)
                switch (min)
                {
                    case < 16: WriteLine("Min in first quarter"); break;
                    case < 31: WriteLine("Min in second quarter"); break;
                    case < 46: WriteLine("Min in third quarter"); break;
                    case <= 59: WriteLine("Min in fourth quarter"); break;
                    default: break;
                }
            else WriteLine("Min isn't between 0 & 59");*/
        }
        private static void Ex4_L3()
        {
            WriteLine("Enter any num:");
            var a = Convert.ToInt32(ReadLine());
            WriteLine((a % 2 == 0) ? "Your num is even" : "Your num is odd");
            WriteLine((a % 3 == 0) ? "Your number is exactly divisible by 3" : "Your num isn't exactly divisible by 3");
            WriteLine((a % 6 == 0) ? "Your number is exactly divisible by 6" : "Your num isn't exactly divisible by 6");
        }
        private static void Ex5_L3()
        {
            WriteLine("Enter a:");
            var a = Convert.ToInt32(ReadLine());
            WriteLine("Enter b:");
            var b = Convert.ToInt32(ReadLine());
            WriteLine("Enter c:");
            var c = Convert.ToInt32(ReadLine());
            var D = (b * b) - (4 * a * c);
            WriteLine($"ax^2+ bx + c = 0   => {a}x^2 + {b}x + {c} = 0");
            if (D < 0 || a == 0)
                WriteLine($"D={D}. There are no roots");
            else if (D == 0)
                WriteLine($"D={D}. There are 1 root\n" +
                    $"x = {-b / (2 * a)}");
            else
                WriteLine($"D={D}. There are 2 roots\n" +
                    $"x1 = {(-b - Math.Sqrt(D)) / (2 * a)}\n" +
                    $"x2 = {(-b + Math.Sqrt(D)) / (2 * a)}");
        }
        private static void Ex6_L3()
        {
            //За завданням кожен 4 рік високосний (що ділиться націло на 4), окрім кожного 100-го, але при цьому кожен 400-й високосний)
            WriteLine("Enter any year:");
            var year = Convert.ToInt32(ReadLine());
            if (year >= 0)
            {
                string? result;
                if (year % 400 != 0)
                    result = (year % 100 == 0 || (year > 0 && year < 4) || year % 4 != 0) ? $"Year {year} isn't intercalary" : $"Year {year} is intercalary";
                else
                    result = "Year is intercalary";
                WriteLine(result);
            }
            else
                WriteLine("Here year can't be < 0");
        }
        private static void Ex7_L3()
        {
            double operand1 = Math.Round(rand.NextDouble() * 100, 3), operand2 = Math.Round(rand.NextDouble() * 100, 3);
            WriteLine("Enter any operation (+ - * / % pow):");
            string sign = ReadLine();
            switch (sign)
            {
                case "+": WriteLine($"{operand1}+{operand2}={Math.Round(operand1 + operand2, 3)}"); break;
                case "-": WriteLine($"{operand1}-{operand2}={Math.Round(operand1 - operand2, 3)}"); break;
                case "*": WriteLine($"{operand1}*{operand2}={Math.Round(operand1 * operand2, 3)}"); break;
                case "/": WriteLine($"{operand1}/{operand2}={Math.Round(operand1 / operand2, 3)}"); break;
                case "%": WriteLine($"{operand1}%{operand2}={Math.Round(operand1 % operand2, 3)}"); break;
                case "pow": WriteLine($"{operand1}^{operand2}={Math.Round(Math.Pow(operand1, operand2), 3)}"); break; //...
                default:
                    WriteLine("Operation unfound");
                    break;
            }
        }
        private static void Ex8_L3()
        {
            WriteLine("Enter num between 0 & 100:");
            var num = Convert.ToInt32(ReadLine());
            if (num >= 0 && num <= 14) { WriteLine("num between [0 - 14]"); }
            else if (num >= 15 && num <= 35) { WriteLine("num between [15 - 35]"); }
            else if (num >= 36 && num <= 50) { WriteLine("num between [36 - 50]"); }
            else if (num > 50 && num <= 100) { WriteLine("num between [50 - 100]"); }
            else { WriteLine("num isn't between [0 - 100]"); }

        }
        private static void Ex9_L3()
        {
            InputEncoding = Encoding.UTF8;
            OutputEncoding = Encoding.UTF8; //для кирилиці
            /*
            Weather (Погода)
            Temperature (Температура)
            Light (cвітло)
            Cloudy (Хмарно)
            Rainy (Дощова)
            Windy (Вітряно)
            Snowfall (Снігопад)
            Humidity (Вологість)
            Forecast (Прогноз)
            Season (Сезон)*/
            Write("Введіть одне з представлених слів для перекладу:" +
                "\nПогода\r\nТемпература\r\nСвітло\r\nХмарно\r\nДощова\r\nВітряно\r\nСнігопад\r\nВологість\r\nПрогноз\r\nСезон\n\nСлово: ");
            string word = ReadLine().ToLower(); // знаю що ToLower() з  перегрузки, але так трішки правильніше)
            WriteLine("Переклад:");
            switch (word)
            {
                case "погода": WriteLine("=> Wheather "); break;
                case "температура": WriteLine("=> Temperature "); break;
                case "світло": WriteLine("=> Light "); break;
                case "хмарно": WriteLine("=> Cloudy "); break;
                case "дощова": WriteLine("=> Rainy "); break;
                case "вітряно": WriteLine("=> Windy "); break;
                case "снігопад": WriteLine("=> Snowfall "); break;
                case "вологість": WriteLine("=> Humidity "); break;
                case "прогноз": WriteLine("=> Forecast "); break;
                case "сезон": WriteLine("=> Season "); break;
                default:
                    WriteLine("Цього слова немає в словнику: ");
                    break;
            }
        }
        private static void Ex10_L3()
        {
            var years = rand.Next(0, 50);
            var salary = rand.Next(1000, 10000);
            /*WriteLine("Enter years :");
            var years = Convert.ToInt32(ReadLine());
            WriteLine("Enter salary :");
            var salary = Convert.ToInt32(ReadLine());*/
            switch (years)
            {
                case < 5: SamePremiumOutput(years, salary, 10); break;
                case < 10: SamePremiumOutput(years, salary, 15); break;
                case < 15: SamePremiumOutput(years, salary, 25); break;
                case < 20: SamePremiumOutput(years, salary, 35); break;
                case < 25: SamePremiumOutput(years, salary, 45); break;
                case >= 25: SamePremiumOutput(years, salary, 50); break;
                default:
            }
        }
        private static void SamePremiumOutput(int years, int salary, double premium) =>
            WriteLine($"With salary ${salary} & {years} {((years == 1 || years == 0) ? "year" : "years")} of working, your premium is {premium}%: " +
                $"{(int)(salary * premium / 100)}");
        private static void Ex11_forL2()
        {
            Write("Enter a: ");
            int a = int.Parse(ReadLine());
            Write("Enter b: ");
            int b = int.Parse(ReadLine());

            Write($"a+b: {(byte)(a + b)}\n" +
                $"a-b: {(byte)(a - b)}\n" +
                $"a*b: {(byte)(a * b)}\n" +
                $"a/b: {(byte)(a / b)} \n" +
                $"a%b: {(byte)(a % b)} \n"); // про використання byte напряму сказано в завданні
        }
        private static void Ex12_forL2()
        {
            double length = rand.Next(1, 1000);
            double pi = 3.14;
            double r = Math.Round(length / (2 * pi), 2);
            WriteLine($"With length: {length}\nr:{r}\n" +
                $"Area: {Math.Round(pi * r * r, 2)}");
        }
        private static void Ex13_forL2()
        {
            WriteLine("What's u name?");
            string name = ReadLine();
            WriteLine($"Hello {name}");
            WriteLine("Hello {0}", name);
            WriteLine("Hello " + name);
            WriteLine(String.Format("Hello {0,50}! Fine", name));
        }
    }
}