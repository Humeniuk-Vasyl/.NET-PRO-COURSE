using System.Text;
using static System.Console;

namespace CourseL17
{
    public class Program
    {
        static Random rnd = new();
        public static void Main()
        {
            //Ex1:
            Ex1Tests();

            //Ex2:
            //Ex2Tests();

            //Ex3:
            //Ex3Tests();

            //Ex4:
            //Ex4Tests();

            //Ex5:
            //Ex5Tests();
        }

        private static void Ex1Tests()
        {
            dynamic a = 1;
            dynamic b = 5;
            dynamic c = 0;
            Calculator.Add(a, b);
            Calculator.Sub(a, b);
            Calculator.Mult(a, b);
            Calculator.Div(a, b);
            Calculator.Div(a, c);

            dynamic a1 = 1.1212;
            dynamic b1 = 0.2237;
            Calculator.Add(a1, b1);
            Calculator.Sub(a1, b1);
            Calculator.Mult(a1, b1);
            Calculator.Div(a1, b1);

            dynamic d = "This";
            dynamic e = "it";
            Calculator.Add(d, e);
            Calculator.Sub(d, e);
            Calculator.Mult(d, e);
            Calculator.Div(d, e);
        }

        private static void Ex2Tests()
        {
            AutoInfo CHEVROLET1 = new("CHEVROLET", "TrailBlazer1", 2000, "Yellow");
            AutoInfo CHEVROLET2 = new("CHEVROLET", "TrailBlazer2", 2000, "Red");
            AutoInfo CHEVROLET3 = new("CHEVROLET", "TrailBlazer3", 2000, "Green");
            AutoInfo CHEVROLET4 = new("CHEVROLET", "TrailBlazer4", 2000, "White");

            IEnumerable<AutoInfo> CHEVROLETS = new[] { CHEVROLET1, CHEVROLET2, CHEVROLET3, CHEVROLET4 };
            CustomerInfo Advard = new("TrailBlazer1", "Advard", "380005554433");
            Advard.PrintInfo(CHEVROLETS);
        }

        private static void Ex3Tests()
        {
            IEnumerable<int> intSequance = new int[30].Select(e => e = rnd.Next(-100, 100)).ToArray();
            WriteLine(string.Join(" ", intSequance.Select(e => e.ToString())));
            WriteLine($"First negative elt: in my int sequance: {intSequance.Where(e => e < 0).FirstOrDefault()}");
            WriteLine($"Last positive elt: in int sequance: {intSequance.Where(e => e > 0).Last()}");
        }

        private static void Ex4Tests()
        {
            FitnessCenterClientInfo client1 = new(1000, 2023, 1, 15);
            FitnessCenterClientInfo client2 = new(1001, 2024, 2, 20);
            FitnessCenterClientInfo client3 = new(1002, 2024, 1, 22);
            FitnessCenterClientInfo client4 = new(1003, 2023, 1, 5);
            FitnessCenterClientInfo client5 = new(1004, 2024, 1, 10);
            FitnessCenterClientInfo client6 = new(1005, 2023, 1, 5);
            IEnumerable<FitnessCenterClientInfo> clients = new[] { client1, client2, client3, client4, client5, client6 };
            clients.PrintClientsInfo();
            FitnessCenterClientInfo LaziestClient = clients
                .Where(e => e.LessonLengthInHour == clients.Select(e => e.LessonLengthInHour).Min())
                .Last(); // точно можна по іншому весь ланцюжок зробити, але це 1 з варіантів 
            WriteLine("\nLaziest (or last of) client:");
            LaziestClient.PrintClientInfo();
        }

        private static void Ex5Tests()
        {
            OutputEncoding = Encoding.UTF8; //для кирилиці
            var dictionary10 = new[] {
                new { word = "погода",      translate = "Wheather"},
                new { word = "температура", translate = "Temperature" },
                new { word = "світло",      translate = "Light"},
                new { word = "хмарно",      translate = "Cloudy"},
                new { word = "дощова",      translate = "Rainy"},
                new { word = "вітряно",     translate = "Windy"},
                new { word = "снігопад",    translate = "Snowfall"},
                new { word = "вологість",   translate = "Humidity"},
                new { word = "прогноз",     translate = "Forecast"},
                new { word = "сезон",       translate = "Season"}
            };

            foreach (var word in dictionary10)
                WriteLine($"{word.word} => {word.translate}");
        }
    }

    #region Ex1_L17
    public static class Calculator
    {
        public static dynamic Add(dynamic arg1, dynamic arg2)
        {
            Print(arg1, arg2, arg1 + arg2, "+");
            return arg1 + arg2;
        }

        public static dynamic Sub(dynamic arg1, dynamic arg2)
        {
            //на кожен тип можна умовно робити різні опрацювання операцій
            //(звісно можна через switch але це лиш для прикладу):
            if (arg1.GetType() == typeof(string) && arg2.GetType() == typeof(string))
            {
                WriteLine("No way to sub strings");
                return 1;
            }
            else
            {
                Print(arg1, arg2, arg1 - arg2, "-");
                return arg1 - arg2;
            }

        }

        public static dynamic Mult(dynamic arg1, dynamic arg2)
        {
            if (arg1.GetType() == typeof(string) && arg2.GetType() == typeof(string))
            {
                WriteLine("No way to mult strings");
                return 1;
            }
            Print(arg1, arg2, arg1 * arg2, "*");
            return arg1 * arg2;
        }

        public static dynamic Div(dynamic arg1, dynamic arg2)
        {
            if (arg1.GetType() == typeof(string) && arg2.GetType() == typeof(string))
            {
                WriteLine("No way to div strings");
                return 1;
            }
            if (arg2 != 0)
                Print(arg1, arg2, arg1 / arg2, "/");
            else
                WriteLine("Can't divide by 0!");
            return (arg2 != 0) ? arg1 / arg2 : null;
        }

        public static void Print(dynamic arg1, dynamic arg2, dynamic res, string opn)
            => WriteLine($"{arg1}{opn}{arg2}={res}");
    }
    #endregion

    #region Ex2_L17
    public class AutoInfo
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public int YearOfRelease { get; set; }
        public string Color { get; set; }

        public AutoInfo(string mark, string model, int yearOfRelease, string color)
        {
            Mark = mark;
            Model = model;
            YearOfRelease = yearOfRelease;
            Color = color;
        }
    }

    public class CustomerInfo
    {
        public string Model { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNum { get; set; }

        public CustomerInfo(string model, string customerName, string phoneNum)
        {
            Model = model;
            CustomerName = customerName;
            PhoneNum = phoneNum;
        }
    }

    public static class CustomerInfoExtension
    {
        public static void PrintInfo(this CustomerInfo customer, IEnumerable<AutoInfo> autos)
        {
            var customerAuto = autos.Where(a => a.Model == customer.Model).FirstOrDefault();

            WriteLine($"Customer info: {customer.CustomerName}: {customer.PhoneNum} and auto:\n" +
            ((customerAuto != null) ? $"{customerAuto.Mark} -> {customerAuto.Model} -> {customerAuto.YearOfRelease} -> {customerAuto.Color}" :
            "Customer auto info isn't in collection."));
        }
    }
    #endregion

    #region Ex4_L17
    public class FitnessCenterClientInfo
    {
        public int IdCode { get; set; }
        public int YearIn { get; set; }
        public int MonthNum { get; set; }
        public int LessonLengthInHour { get; set; }

        public FitnessCenterClientInfo(int idCode, int yearIn, int monthNum, int lessonLengthInHour)
        {
            IdCode = idCode;
            YearIn = yearIn;
            MonthNum = monthNum;
            LessonLengthInHour = lessonLengthInHour;
        }
    }

    public static class FitnessCenterClientInfoExtension
    {
        public static void PrintClientsInfo(this IEnumerable<FitnessCenterClientInfo> clients)
        {
            foreach (var client in clients)
                client.PrintClientInfo();
        }

        public static void PrintClientInfo(this FitnessCenterClientInfo client)
            => WriteLine($"Client id:{client.IdCode} -> Year of start: {client.YearIn}\n" +
                    $"months: {client.MonthNum} -> Lessons in hour: {client.LessonLengthInHour}");
    }
    #endregion
}