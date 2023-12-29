using static System.Console;
using static System.Math;

namespace CourseL12
{
    class Program
    {
        static Random rnd = new();
        static void Main()
        {
            //Ex1
            //Calculator.Calculate();

            //Ex2
            //ForEx2_L12();

            //Ex3
            ForEx3_L12();
        }

        private static void ForEx2_L12()
        {
            Worker[] workers = new Worker[5];
            string newSubName = "", newInitials = "", newPost = "";
            int newAdmissionYear = 0;

            WriteLine("You need to enter info about 5 workers:");
            for (int i = 0; i < 5;)
            {
            Declare:
                WriteLine("Enter new subName:");
                newSubName = ReadLine();
                WriteLine("Enter new initials:");
                newInitials = ReadLine();
                WriteLine("Enter new Post:");
                newPost = ReadLine();

                if (newSubName == "" || newInitials == "" || newPost == "")
                {
                    WriteLine("SubName, initials & Post can't be empty!");
                    goto Declare;
                }

            YearInit:
                WriteLine("Enter new Admission year:");
                try
                {
                    newAdmissionYear = int.Parse(ReadLine());
                    Worker.YearCheck(newAdmissionYear);
                }
                catch (AdmissionYearException exp)
                {
                    WriteLine($"{exp.Message}");
                    goto YearInit;
                }
                catch (FormatException exp2)
                {
                    WriteLine($"{exp2.Message}");
                    goto YearInit;
                }
                // тум можна далі добавляти нові catch-i але для суті завдання цих 2-х достанього.

                if (i == 0)
                    goto Inits;
                else if (string.Compare(newSubName, workers[i - 1].SubName) <= 0)
                {
                    WriteLine("New workers SubName must comes after previous worker alphabetically");
                    goto Declare;
                }

            Inits:
                workers[i] = new Worker(newSubName, newInitials, newPost, newAdmissionYear);
                WriteLine(workers[i]);
                i++;
            }

            Worker.ShowWorkersInfo(workers);
            Worker.FilterByExperience(workers, 10);
        }

        public static void ForEx3_L12()
        {
            Price[] prices = new Price[2];
            string? newGoodName = "", newShopName = "";
            string selectedShopName = "";
            bool isSelectedShopNameExist = false;

            for (int i = 0; i < 2;)
            {
            StartEnters:
                WriteLine("Enter good name:");
                newGoodName = ReadLine();
                WriteLine("Enter shop name:");
                newShopName = ReadLine();

                if (newGoodName == "" || newShopName == "")
                {
                    WriteLine("Good name & shop name can't be empty!");
                    goto StartEnters;
                }
                else if (i>0 && string.Compare(newShopName, prices[i - 1].GoodShopName) <= 0)
                {
                    WriteLine("New good shop name must comes after previous alphabetically");
                    goto StartEnters;
                }
                prices[i] = new Price(newGoodName, newShopName, rnd.NextDouble() * (1000 - 100) + 100);
                WriteLine(prices[i]);
                i++;
            }

        EnterShopName:
            WriteLine("Enter shop name to show good:");
            selectedShopName = ReadLine();

            foreach (var good in prices)
                if (selectedShopName == good.GoodShopName)
                {
                    isSelectedShopNameExist = true;
                    WriteLine(good);
                    return;
                }

            try
            {
                IsShopNameExist(isSelectedShopNameExist);
            }
            catch (ShopExistException exp)
            {
                WriteLine(exp.Message);
                goto EnterShopName;
            }
        }
        private static void IsShopNameExist(bool isSelectedShopNameExist)
        {
            if (!isSelectedShopNameExist)
                throw new ShopExistException("Shop isn't exist!");
        }// тобто вся відмінність в такому випадку в тому, що ми викликаємо exception сторонньо,
         // в даному випадку з Program,
         // бо необхідно перевірити певну-достатню кількість екземплярів класу, а не кожен окремо на excepton
    }

    #region Ex1_L12
    static class Calculator
    {
        static string? _a, _b;
        static double a, b;
        static bool end = false;

        public static void Calculate()
        {
            while (end == false)
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
                WriteLine("Enter any operation (+ - * / or 0 for exit):");
                string sign = ReadLine();
                switch (sign)
                {
                    case "0": end = true; break;
                    case "+": Add(); break;
                    case "-": Sub(); break;
                    case "*": Mult(); break;
                    case "/": Div(); break;
                    default:
                        WriteLine("Operation unfound. Plz enter else sign from existing:\n" +
                            "+ - * / or 0 for exit");
                        goto Start;
                }
            }
        }

        static void Add() =>
                WriteLine($"{a}+{b}={a + b}");

        static void Sub() =>
            WriteLine($"{a}-{b}={a - b}");


        static void Mult() =>
            WriteLine($"{a}*{b}={Round(a * b, 3)}");

        static void Div()
        {
            try
            {
                WriteLine($"{a}/{b}={(int)a / (int)b}"); // пару хвилин тупив і не міг поняти чому не можу відловити помилку, а в мене був double)
            }
            catch (DivideByZeroException e)
            {
                WriteLine(e.Message);
                //WriteLine("b can't = 0");
            }
        }
    }
    #endregion

    #region Ex2_L12

    struct Worker
    {
        public string? SubName { get; }
        string Initials { get; set; }
        string Post { get; set; }
        int AdmissionYear { get; set; }

        public Worker()
        {
            SubName = "No name";
            Initials = "No initials";
            Post = "No post";
            AdmissionYear = 1960;       // conditionally min admission year
        }

        public Worker(string? subName, string initals, string post, int admissionYear)
        {
            SubName = subName;
            Initials = initals;
            Post = post;
            AdmissionYear = admissionYear;
        }

        public static void YearCheck(int year)
        {
            if (year < 1960 || year > 2024)
                throw new AdmissionYearException("year must be between [1960;2024]", year);
        }

        public override readonly string ToString() =>
            $"{SubName} {Initials}, {Post}. Adm. year: {AdmissionYear}\n";

        public static void ShowWorkersInfo(Worker[] workers)
        {
            WriteLine("Workers info:");
            foreach (var worker in workers)
                WriteLine(worker);
        }

        public static void FilterByExperience(Worker[] workers, int experience)
        {
            WriteLine($"Workers with experience > {experience}");
            var yearNow = DateTime.Now.Year;
            foreach (var worker in workers)
                if ((yearNow - worker.AdmissionYear) > experience)
                    WriteLine(worker);
        }
    }

    class AdmissionYearException : Exception
    {
        public int Year { get; }
        public AdmissionYearException() { }

        public AdmissionYearException(string? message) : base(message) { }

        public AdmissionYearException(string? message, Exception? innerException) : base(message, innerException) { }

        public AdmissionYearException(string message, int year)
        : this(message) => Year = year;
    }
    #endregion

    #region Ex3_L12
    struct Price
    {

        string? GoodName { get; set; }
        public string GoodShopName { get; }
        double GoodPrice { get; set; }

        public Price(string? goodName, string shopName, double goodPrice)
        {
            GoodName = goodName;
            GoodShopName = shopName;
            GoodPrice = goodPrice;
        }

        public override readonly string ToString() =>
            $"{GoodName} -> {Round(GoodPrice,3)} UAH. Contains in {GoodShopName}";
    }

    class ShopExistException : Exception
    {
        public string? ShopName { get; }
        public ShopExistException() { }

        public ShopExistException(string? message) : base(message) { }

        public ShopExistException(string? message, Exception? innerException) : base(message, innerException) { }

        public ShopExistException(string message, string shopName)
        : this(message) => ShopName = shopName;
    }
    #endregion
}