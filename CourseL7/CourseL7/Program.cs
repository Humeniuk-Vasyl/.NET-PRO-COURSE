using static System.Console;
using static System.Math;
namespace CourseL7
{
    public class Program
    {
        static readonly Random rnd = new();
        static void Main()
        {
            /*//Ex1
            Address adress1 = new()
            {
                Country = " ",
                //Street = " ",
                //city = " ",
                House = 1,
                Apartment = 2,
                Index = -20 // попробую вивести повідомлення про переініціалізацію через консоль
            };
            adress1.ShowAdress();*/

            /*//Ex2
            Kitten kit = new()
            {
                Name = "SuperKit",
                Age = 1,
                FurColor = "green",
                EyeColor = "red",
            };
            kit.KitSay(3);*/

            /*//Ex3
            BankAccount bancA1 = new()
            {
                DateOfStart = new DateTime(2022, 10, 31),
                PercentRate = 12,
                StartSum = 1000
            };
            bancA1.PrintStartInfo();
            bancA1.PrintDaysFromStart();
            bancA1.PrintSum();
            bancA1.YearsToCountSum = 10;
            bancA1.PrintSum();*/

            /*//Ex4
            Triangle tr1 = new() { A = 10, B = 15, C = 8 };
            tr1.PrintInfo(); // по факту лиш цей метод має бути доступний для юзера
            
            Triangle tr2 = new(10, 15, 15);
            tr2.PrintInfo();

            Triangle unrealTr = new(10, 15, 100);
            unrealTr.PrintInfo();*/

            /*//Ex5
            MyPoint a = new() { X = 10, Y = 10 };
            MyPoint b = new(20, 10, "b");
            MyPoint c = new(20, 5);
            MyPoint d = new(10, 5);

            MyPoint b1 = new(30, 10);
            MyPoint c1 = new(30, 5);

            MyFigure figure1 = new(a, b, c);
            figure1.Name = "Triangle";
            figure1.PrintFigureInfo();
            figure1.PrintPerimeter();
            //figure1.PrintMaxFigureLength(); //працює для трикутників

            MyFigure unrealTr = new(new MyPoint(10, 10), new MyPoint(20, 10), new MyPoint(50, 10));
            unrealTr.Name = "Triangle";
            unrealTr.PrintFigureInfo();
            unrealTr.PrintPerimeter();

            MyFigure figure2 = new(a, b, c, d);
            figure2.Name = "Square";
            figure2.PrintFigureInfo();
            figure2.PrintPerimeter();

            MyFigure figure3 = new(a, b1, c1, d);
            figure3.Name = "Rectangle";
            figure3.PrintFigureInfo();
            figure3.PrintPerimeter();*/

            //Ex6_forL6();
        }

        #region Ex6_forL6
        static void Ex6_forL6()
        {
            int[] myArray = MethodForEx6(), subArray;
            double sum = 0, evenSum = 0, mean;
            int evenHigherMeanCounter = 0;
            //Досі обійдемся без LINQ, списків, колекцій і т.д.)
            WriteLine("Created array:");
            for (int i = 0; i < 10; i++)
            {
                Write($"{myArray[i]} ");
                sum += myArray[i];
                evenSum += (myArray[i] % 2 == 0) ? myArray[i] : 0;
            }
            mean = Round(sum / 10, 2);
            for (int i = 0; i < 10; i++)
                if (myArray[i] > mean)
                    evenHigherMeanCounter++;
            subArray = new int[evenHigherMeanCounter];
            for (int i = 0, t = 0; i < 10; i++)
            {
                if (myArray[i] > mean)
                {
                    subArray[t] = myArray[i];
                    t++;
                }
            }
            WriteLine($"\nSum of all elements {sum}\n" +
                $"Sum of even elements: {evenSum}\n" +
                $"Mean: {mean}\n" +
                $"And all even > mean:");
            foreach (var item in subArray)
                Write($"{item} ");
        }

        private static int[] MethodForEx6()
        {
            int[] myArray = new int[10];
            for (int i = 0; i < 10; i++)
                myArray[i] = rnd.Next(1, 100);
            return myArray;
        }
        #endregion
    }

    #region Ex1_L7
    public class Address
    {
        private string? country, city, street;
        private int house, apartment, index;
        public string? Country { get => country; set => country = (value.Length >= 3) ? value : "no set"; }
        public string? City { get => (city != null) ? city : "nothing to get"; set => city = value ?? "no set"; } // я умовно зобразив як можна присвоїти сходу
        public string? Street { get => (street != null) ? street : "nothing to get"; set => street = value; }

        public int House { get => house; set => house = value; }
        public int Apartment { get => apartment; set => apartment = value; }
        public int Index
        {
            get => index;
            set
            {
                if (value < 0)
                    while (true)
                    {
                        WriteLine("Enter new index, qaz of previous setted in code is bad:");
                        string _index = ReadLine();
                        if (!int.TryParse(_index.ToString(), out index) || index < 0)
                            WriteLine("Index wasn't parsed or < 0");
                        else
                            break;
                    }
                else
                    index = value;
            }
        }

        public void ShowAdress()
        {
            WriteLine("Country: " + Country + "\nCity: " + City +
                "\nStreat: " + Street + "\nApartment: " + Apartment + "\nIndex: " + Index);
        }
    }
    #endregion

    #region Ex2_L7
    internal class Kitten
    {
        string? name, furColor, eyeColor;
        int age;

        public string? Name { get => name; set => name = value; }
        public string? FurColor { get => furColor; set => furColor = value; }
        public string? EyeColor { get => eyeColor; set => eyeColor = value; }
        public int Age { get => age; set => age = value; }

        internal void KitSay(int v)
        {
            for (int i = 0; i < v; i++)
                WriteLine("Myau! ^^");
        }
    }
    #endregion

    #region Ex3_L7
    class BankAccount
    {
        public BankAccount()
        {
            DateOfStart = DateTime.Now; // по дефолту сьогодні
            percentRate = 10;           // по дефолту 10
            StartSum = 0;               // ну і 0
        }
        public BankAccount(int pRate, int sSum)
        {
            percentRate = pRate;
            startSum = sSum;
        }

        private DateTime dateOfStart;
        private double percentRate, startSum, sum, addSum;

        public DateTime DateOfStart { get => dateOfStart; set => dateOfStart = value; }
        public double PercentRate { get => percentRate; set => percentRate = value; }
        public double StartSum { get => startSum; set => startSum = value; }
        public int YearsToCountSum { get; set; } // сказано що це лише параметр, нічого про змінну
        public void PrintStartInfo() => WriteLine($"Start sum: {StartSum}, Date of start: {DateOfStart.ToShortDateString()}"); // для виводу початкових даних

        private int CalcDaysFromStart() => DateTime.Now.Subtract(dateOfStart).Days; // логіка мабуть в тому що зовнішній юзер не має відношення до логіки розрахунку всередині,
                                                                                    // лише подає параметр, оброблений конструктором та може вивести результат назовні
        public void PrintDaysFromStart() => WriteLine($"Days from start: {CalcDaysFromStart()}");
        private double CalcSumAmount()
        {
            addSum = startSum * Pow((1 + percentRate / 100), DateTime.Now.Subtract(dateOfStart).Days / 365);
            sum = startSum * Pow((1 + percentRate / 100), YearsToCountSum);
            return Round(addSum + sum, 2);
        }
        public void PrintSum() => WriteLine($"Sum on your account from date of start {dateOfStart.ToShortDateString()} to now + {YearsToCountSum} years: {CalcSumAmount()}");
    }
    #endregion

    #region Ex4_L7

    class Triangle
    {
        private double a, b, c, halfPerimeter;
        bool unrealCheck = false;
        public double A { get => a; set => a = (value > 0) ? value : 1; }
        public double B { get => b; set => b = (value > 0) ? value : 1; }
        public double C { get => c; set => c = (value > 0) ? value : 1; }
        public Triangle()
        {

            //UnreaCheck(); //При цьому варіанті перевірка не має сенсу,
            //оскільки ми ще не присвоїли сторонам довжини
        }                 //а краще взагалі не дозволяти пустий конструктор
        public Triangle(double A, double B, double C)
        {
            a = A; b = B; c = C;
            UnreaCheck();
        }

        private void UnreaCheck()
        {
            unrealCheck = a >= (b + c) || b >= (a + c) || c >= (a + b);
            if (unrealCheck) WriteLine("You have created unreal triagle!");
        }

        private double CalcPerimeter()
        {
            halfPerimeter = (a + b + c) / 2;
            return (a + b + c);
        }
        private double CalcArea()
        {
            CalcPerimeter();
            return Round(Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c)), 2);
        }
        public void PrintInfo()=>
            WriteLine((!unrealCheck)?$"Triangle ({a},{b},{c}) area: {CalcArea()} & perimeter: {CalcPerimeter()}":
                "No info!");
    }
    #endregion

    #region Ex5_L7
    class MyPoint
    {
        private double x, y;
        private string name;
        public MyPoint() { }
        public MyPoint(double X, double Y)
        {
            x = X;
            y = Y;
            name = "No name point";
        }
        public MyPoint(double X, double Y, string Name)
        {
            x = X;
            y = Y;
            name = Name;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public string Name { get => name; set => name = value; }
    }
    class MyFigure
    {
        private MyPoint[] points;
        private string name;
        private bool unrealInfo = false;
        double FigureLength;
        public MyFigure(MyPoint p1, MyPoint p2, MyPoint p3)
        {
            points = new MyPoint[3] { p1, p2, p3 };
            unrealInfo = UnrealCheck();
            if (unrealInfo == true)
                WriteLine("\nYou have created unreal 2-dimensional triangle!");
        }

        private bool UnrealCheck()
        {
            bool result = false;
            // оскільки ми знаємо що на вході трикутник то обійдемся без циклів
            var lengths = new double[3] { CalcFigureLength(points[0], points[1]), CalcFigureLength(points[1], points[2]), CalcFigureLength(points[2], points[0]) };
            if (lengths[0] > (lengths[1] + lengths[2]) ||
             lengths[1] > (lengths[0] + lengths[2]) ||
             lengths[2] > (lengths[0] + lengths[1]) ||
             points[0].X == points[1].X && points[1].X == points[2].X ||
             points[0].Y == points[1].Y && points[1].Y == points[2].Y)
                result = true;
            return result;
        }

        public MyFigure(MyPoint p1, MyPoint p2, MyPoint p3, MyPoint p4)
        {
            points = new MyPoint[4] { p1, p2, p3, p4 };
            // очевидно що тут так само можна було б робити перевірки як і з трикутником еле мені лінь)
            // + в завданні за це нічого не сказано)
        }
        
        internal MyPoint[] Points { get => points; set => points = value; }
        
        public string Name { get => name; set => name = value; }
        
        public double CalcFigureLength(MyPoint p1, MyPoint p2)
        {
            FigureLength = Round(Sqrt(Pow(p2.X - p1.X, 2) + Pow(p2.Y - p1.Y, 2)), 2);
            return FigureLength;
        }
        
        /*
        private (double,MyPoint,MyPoint) CalcMaxFigureLength()
        {
            int length = Points.Length;
            double maxFigureLength = 0, tmpFigureLength;
            MyPoint from = new MyPoint(), to = new MyPoint();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    tmpFigureLength = Round(Sqrt(Pow(points[i].X - points[j].X, 2) + Pow(points[i].Y - points[j].Y, 2)), 2);
                    if (tmpFigureLength > maxFigureLength)
                    {
                        maxFigureLength = tmpFigureLength;
                        from = Points[i];
                        to = Points[j];
                    }
                }
            }
            return (maxFigureLength, from, to);
        } 
        public void PrintMaxFigureLength()
        {
            var tmp = CalcMaxFigureLength();
            WriteLine($"Max figure length: {tmp.Item1} from ({tmp.Item2.X};{tmp.Item2.Y}) to ({tmp.Item3.X};{tmp.Item3.Y})");
        } // якщо б нам потрібно було найти найдовшу сторону і звідки куди
        */
        
        private double CalcPerimeter()
        {
            if (unrealInfo == true)
                return 0;

            double perimeter = 0;
            var length = points.Length;
            for (int i = 1; i < length; i++)
                perimeter += CalcFigureLength(points[i], points[i - 1]);
            perimeter += CalcFigureLength(points[0], points[length - 1]);
            return perimeter;
        }
        
        public void PrintPerimeter() =>
            WriteLine((unrealInfo != true) ? $"\nPerimeter of {name}: {CalcPerimeter()}" : "unreal to calculate perimeter!\n");

        public void PrintFigureInfo()
        {
            Write($"\nYour {name} with points: ");
            foreach (var p in points)
                Write($"({p.X},{p.Y}) ");
            WriteLine();
        }
    }
    #endregion
}