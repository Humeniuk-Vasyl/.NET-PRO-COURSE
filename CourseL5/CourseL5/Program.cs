using static System.Console;
using static System.Math;
namespace CourseL5
{
    class Program
    {
        static Random rnd = new();
        public static void Main()
        {
            //WriteLine(Ex1_L5(10,11,14)); //11,66
            //WriteLine(Ex2_L5(10, 10)); //11
            //WriteLine(Ex3_L5(2001)); //22, сказано що на вході лише рік, а значить повернення теж рік
            //Ex4_L5();
            //Ex5_L5();
            //Ex6_L5();
            //Ex7_L5();
            //Ex8_L5();
            //Ex9_L5();
            //Ex10_L5();
            Ex11_L5();
            //Ex12_L5forL4();
            //Ex13_L5forL4();
        }

        private static double Ex1_L5(int x, int y, int z) =>
            Round((double)(x + y + z) / 3, 2);

        private static double Ex2_L5(double x, double y) =>
            //Min(x, y); // or
            x > y ? x : y;

        private static string Ex3_L5(int year) =>
            (year < DateTime.Now.Year) ?
                $"Your age is: {DateTime.Now.Year - year}" :
                "year can't be higher than now";

        #region Ex4_L5
        private static void Ex4_L5()
        {
            string _a, _b;
            int a, b; // в завданні сказано цілі числа, хоча очевидно оптимально було б double
            bool end = false;
            while (end != true)
            {
                while (true)
                {
                    Write("Enter a: ");
                    _a = ReadLine();
                    Write("Enter b: ");
                    _b = ReadLine();
                    if (int.TryParse(_a, out a) && int.TryParse(_b, out b))
                        break;
                    WriteLine("a or b wasn't parsed. Plz enter again");
                }
            Start:
                WriteLine("Enter any operation (+ - * / % pow or 0 for exit):");
                string sign = ReadLine();
                switch (sign)
                {
                    case "0": end = true; break;
                    case "+": Add(a, b); break;
                    case "-": Sub(a, b); break;
                    case "*": Mult(a, b); break;
                    case "/": Div(a, b); break;
                    default:
                        WriteLine("Operation unfound. Plz enter else sign from existing:\n" +
                            "+ - * / or 0 for exit");
                        goto Start;
                }
            }
        }
        private static void Add(int a, int b) =>
            WriteLine($"{a}+{b}={a + b}");

        private static void Sub(int a, int b) =>
            WriteLine($"{a}-{b}={a - b}");

        private static void Mult(int a, int b) =>
            WriteLine($"{a}*{b}={a * b}");

        private static void Div(int a, int b) =>
            WriteLine((b != 0) ? $"{a}/{b}={a / b}" : "b can't = 0");
        #endregion

        #region Ex5_L5
        private static void Ex5_L5()
        {
            string _amount;
            double amount;
            bool end = false;
            while (end != true)
            {
                while (true)
                {
                    Write("Enter money amount >=0: ");
                    _amount = ReadLine();
                    if (double.TryParse(_amount, out amount) && amount > 0)
                        break;
                    WriteLine("amount wasn't parsed or <=0. Plz enter again");
                }
            Start:
                IntroCurrency("from");
                var currencyFrom = ReadLine();
                IntroCurrency("to");
                var currencyTo = ReadLine();
                switch (currencyFrom)
                {
                    case "0":
                        end = true;
                        break;
                    case "1":
                        switch (currencyTo)
                        {
                            case "0": end = true; break;
                            case "1": AnyConvert(amount, "USD", "USD", ConvertCoefficients.USD_To_USD); break;
                            case "2": AnyConvert(amount, "USD", "UAH", ConvertCoefficients.USD_To_UAH); break;
                            case "3": AnyConvert(amount, "USD", "PLN", ConvertCoefficients.USD_To_PLN); break;
                            case "4": AnyConvert(amount, "USD", "EUR", ConvertCoefficients.USD_To_EUR); break;
                            default: CurrencyUnfoundError(); goto Start;
                        }
                        break;
                    case "2":
                        switch (currencyTo)
                        {
                            case "0": end = true; break;
                            case "1": AnyConvert(amount, "UAH", "USD", ConvertCoefficients.UAH_To_USD); break;
                            case "2": AnyConvert(amount, "UAH", "UAH", ConvertCoefficients.UAH_To_UAH); break;
                            case "3": AnyConvert(amount, "UAH", "PLN", ConvertCoefficients.UAH_To_PLN); break;
                            case "4": AnyConvert(amount, "UAH", "EUR", ConvertCoefficients.UAH_To_EUR); break;
                            default: CurrencyUnfoundError(); goto Start;
                        }
                        break;
                    case "3":
                        switch (currencyTo)
                        {
                            case "0": end = true; break;
                            case "1": AnyConvert(amount, "PLN", "USD", ConvertCoefficients.PLN_TO_USD); break;
                            case "2": AnyConvert(amount, "PLN", "UAH", ConvertCoefficients.PLN_TO_UAH); break;
                            case "3": AnyConvert(amount, "PLN", "PLN", ConvertCoefficients.PLN_TO_PLN); break;
                            case "4": AnyConvert(amount, "PLN", "EUR", ConvertCoefficients.PLN_TO_EUR); break;
                            default: CurrencyUnfoundError(); goto Start;
                        }
                        break;
                    case "4":
                        switch (currencyTo)
                        {
                            case "0": end = true; break;
                            case "1": AnyConvert(amount, "EUR", "USD", ConvertCoefficients.EUR_TO_USD); break;
                            case "2": AnyConvert(amount, "EUR", "UAH", ConvertCoefficients.EUR_TO_UAH); break;
                            case "3": AnyConvert(amount, "EUR", "PLN", ConvertCoefficients.EUR_TO_PLN); break;
                            case "4": AnyConvert(amount, "EUR", "EUR", ConvertCoefficients.EUR_TO_EUR); break;
                            default: CurrencyUnfoundError(); goto Start;
                        }
                        break;
                    default:
                        CurrencyUnfoundError();
                        goto Start;
                }
            }
        }
        private static void IntroCurrency(string from_to) =>
            WriteLine($"select the num of currency {from_to} which you want to convert " +
                                "(1:USD 2:UAH 3:PLN 4:EUR or 0 for exit):");

        private static void CurrencyUnfoundError() =>
            WriteLine("Currency unfound. Plz enter else from existing:\n" +
                                        "1:USD 2:UAH 3:PLN 4:EUR or 0 for exit");

        //  курси валют взяті з: https://minfin.com.ua/ua/currency/converter/
        private static void AnyConvert(double amount, string? currencyFrom, string? currencyTo, double coeff) =>
                    WriteLine($"Converted from {currencyFrom} to {currencyTo} with course {coeff}: " +
                        $"{amount} {currencyFrom} ~ {Round(amount * coeff, 4)} {currencyTo}");
        #endregion

        #region Ex6_L5
        private static void Ex6_L5()
        {
            //int x, y, z; // variable declaration can be inlined
            MethodWithOutEx6_L5(out int x, out int y, out int z);
            WriteLine($"After:\tx = {x}, y = {y}, z = {z}");

            int x2 = rnd.Next(1, 100), y2 = rnd.Next(1, 100), z2 = rnd.Next(1, 100);
            WriteLine($"With ref operator: x was {x2}, y was {y2}, z was {z2}");
            MethodWithRefEx6_L5(ref x2, ref y2, ref z2);
            WriteLine($"After:\tx = {x2}, y = {y2}, z = {z2}");

        }
        private static void MethodWithOutEx6_L5(out int x, out int y, out int z)
        {
            x = rnd.Next(1, 100); // with out we must init variables here
            y = rnd.Next(1, 100);
            z = rnd.Next(1, 100);
            WriteLine($"With out operator: x was {x}, y was {y}, z was {z}");
            x *= 10;
            y *= 10;
            z *= 10;
        }
        private static void MethodWithRefEx6_L5(ref int x, ref int y, ref int z)
        {
            x *= 10; // with ref we can use previously initialized variables
            y *= 10;
            z *= 10;
        }
        #endregion

        private static void Ex7_L5()
        {
            string? _width, _height;
            double width, height; // sometimes we must declare variables like them, even if we uses out
            while (true)
            {
                Write("Enter width: ");
                _width = ReadLine();
                Write("Enter height: ");
                _height = ReadLine();
                if (double.TryParse(_width, out width) && double.TryParse(_height, out height) && width > 0 && height > 0)
                    break;
                WriteLine("Width or height wasn't parsed <= 0. Plz enter again");
            }
            WriteLine($"Square of rectangle with width: {width} & height: {height} is: {Round(width * height, 4)}\n" +
                $"And perimeter is: {Round(2 * (width + height), 4)}");
        }

        #region Ex8_L5
        private static void Ex8_L5()
        {
            int n;
            while (true)
            {
                Write("Enter n >=0: ");
                string? _n = ReadLine();
                if (int.TryParse(_n, out n) && n > 0)
                    break;
                WriteLine("n wasn't parsed or <=0. Plz enter again");
            }
            RecursEx8_L5_v1(n, n - 1);
            WriteLine();
            RecursEx8_L5_v2(1, n);
        }
        private static void RecursEx8_L5_v1(int n, int start)
        {
            if (n == 1)
                return;
            RecursEx8_L5_v1(--n, start);
            Write($"{n} ");
            if (n == start)
                Write($"{start + 1}");
        }
        //or
        static void RecursEx8_L5_v2(int start, int end)
        {
            if (start > end)
                return;
            Write($"{start} ");
            RecursEx8_L5_v2(start + 1, end);
        }
        #endregion

        #region Ex9_L5
        private static void Ex9_L5()
        {
            int n;
            while (true)
            {
                Write("Enter n >=0: ");
                string? _n = ReadLine();
                if (int.TryParse(_n, out n) && n > 0)
                    break;
                WriteLine("n wasn't parsed or <=0. Plz enter again");
            }
            int sum = 0;
            RecursEx9_L5(n, n - 1, ref sum);
            WriteLine($"result sum of [1,n]: {sum}");
        }
        private static void RecursEx9_L5(int n, int start, ref int sum)
        {
            if (n == 1)
                return;
            RecursEx9_L5(--n, start, ref sum);
            sum += n;
            if (n == start)
                sum += start + 1;
        }

        #endregion

        private static void Ex10_L5()
        {
            int n, grade = 0;
            while (true)
            {
                Write("Enter n >=0: ");
                string? _n = ReadLine();
                if (int.TryParse(_n, out n) && n > 0)
                    break;
                WriteLine("n wasn't parsed or <=0. Plz enter again");
            }
            while (n > 0)
            {
                n /= 10;
                grade++;
            }
            WriteLine($"grade of n is: {grade}");
        }

        #region Ex11_L5
        private static void Ex11_L5()
        {
            //Перш за все представимо що кредит безпроцентний, або розстрочка як в приват чи моно розділена на однакові платежі.
            //Однак місячний платіж буде перераховуватись в залежності від того скільки цього місяця було введено коштів + можливі 3 результату:
            //1. кредит сплачено, все гуд)
            //2. кредит сплачено і переплата повернеться на карту)
            //3) кредит не сплачено за вказаний період з наслідками(
            string? _sum, _timeInMonths;
            double sum, timeInMonths; // sometimes we must declare variables like them, even if we uses out
            while (true)
            {
                Write("Enter sum of credit: ");
                _sum = ReadLine();
                Write("Enter time in mounts: ");
                _timeInMonths = ReadLine();
                if (double.TryParse(_sum, out sum) && double.TryParse(_timeInMonths, out timeInMonths) &&
                    sum > 1 && timeInMonths > 1 && sum > timeInMonths)
                    break;
                WriteLine("sum or time wasn't parsed or < 1. Also check that the sum isn't <= than time in months.");
            }
            double monthlyPay = Round(sum / timeInMonths, 2);
            EcoBankEx11_L5(sum, monthlyPay, timeInMonths);
        }

        private static void EcoBankEx11_L5(double sum, double monthlyPay, double timeInMonths)
        {
            int monthsCounter = 0;
            double tmpMonthlyPay = 0;
            string? _tmpMonthlyPay = "";
            WriteLine("Hello user. Your bank info:");
            while (true)
            {
                WriteLine($"\nMonth {monthsCounter + 1}.\nSum of debt: {sum}.\nFor this month you need to pay {monthlyPay}");

                while (true)
                {
                    Write("Enter monthly payment: ");
                    _tmpMonthlyPay = ReadLine();
                    if (double.TryParse(_tmpMonthlyPay, out tmpMonthlyPay) && tmpMonthlyPay > 0)
                        break;
                    WriteLine("monthly payment wasn't parsed or <= 0. Plz enter again");
                }

                if (tmpMonthlyPay < monthlyPay)
                    WriteLine("Entered monthly payment is less than necessary. Your next payments will be recalculated.");
                else if (tmpMonthlyPay > monthlyPay)
                    WriteLine("Entered monthly payment is higher than necessary. Your next payments will be recalculated.");
                else
                    WriteLine("All's fine. Go for next month.");
                monthsCounter++;
                sum -= Round(tmpMonthlyPay, 2);
                if (monthsCounter == timeInMonths && sum > 0)
                {
                    WriteLine($"Credit is overdue! U need to pay the full arrears: {sum} to the end of month or THE POLICE WILL COME TO U!");
                    break;
                }
                if (sum == 0)
                {
                    WriteLine("Credit is repaid. Congratulations!");
                    break;
                }
                else if (sum < 0)
                {
                    WriteLine($"Congratulations, credit is repaid! The remnant amount of {Abs(sum)} will be returned to your card!");
                    break;
                }
                else
                    monthlyPay = Round(sum / (timeInMonths - monthsCounter), 2);
            }
        }
        #endregion

        private static void Ex12_L5forL4() // same as Ex. 9
        {
            int n;
            while (true)
            {
                Write("Enter n >=0: ");
                string? _n = ReadLine();
                if (int.TryParse(_n, out n) && n > 0)
                    break;
                WriteLine("n wasn't parsed or <=0. Plz enter again");
            }
            int sum = 0;
            RecursEx9_L5(n, n - 1, ref sum);
            WriteLine($"result sum of [1,n]: {sum}");
        }
        private static void Ex13_L5forL4()
        {
            // представимо що з першого разу користувач вводить новий пін код, а наступні 3 рази звіряються з першим. Тоді:
            int pin = 0, tmpPin = 0, counter = 0;
            string? _pin = "", _tmpPin = "";
            while (true)
            {
                if (counter == 0)
                {
                    Write("Enter new pin >=1000: ");
                    _pin = ReadLine();
                    if (int.TryParse(_pin, out pin) && pin >= 1000)
                        counter++;
                    else
                        WriteLine("pin wasn't parsed or <=1000. Plz enter again");
                }
                else
                {
                    Write("Enter your pin: ");
                    _tmpPin = ReadLine();
                    if (int.TryParse(_tmpPin, out tmpPin) && tmpPin == pin)
                    {
                        WriteLine($"Hello Mr.Vasyl. Your PIN is: {pin}");
                        break;
                    }
                    else if (counter < 3)
                    {
                        counter++;
                        WriteLine("pin wasn't parsed or incorrect. Plz enter again");
                    }
                    else
                    {
                        WriteLine("Your card is blocked.");
                        break;
                    }
                }
            }
        }
    }
    public struct ConvertCoefficients
    {
        //FROM USD
        public const double USD_To_USD = .9868,
        USD_To_UAH = 37.3,
        USD_To_PLN = 3.9957,
        USD_To_EUR = .9075,
        //FROM UAH
        UAH_To_UAH = 1,
        UAH_To_USD = .0265,
        UAH_To_PLN = .1071,
        UAH_To_EUR = .0243,
        //FROM PLN
        PLN_TO_PLN = .9641,
        PLN_TO_USD = .2381,
        PLN_TO_UAH = 9,
        PLN_TO_EUR = .219,
        //FROM EUR
        EUR_TO_EUR = .983,
        EUR_TO_USD = 1.0688,
        EUR_TO_UAH = 40.4,
        EUR_TO_PLN = 4.3278;
    }
}