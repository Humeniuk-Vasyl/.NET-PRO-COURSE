using static System.Console;
using static System.Math;

namespace CourseL10
{
    class Program
    {
        static void Main()
        {
            /*//Ex1
            Calculator.Calculate();
            */

            /*//Ex2
            Convector.Conversion();
            */

            /*//Ex3
            var myLongSentence = "Создайте программу, в которой создайте статический класс StringExtension " +
                "(длина строки), в теле\r\nкласса создайте расширяющий метод StrCount " +
                "который будет осуществлять подсчёт количество\r\nэлементов в строке.";
            WriteLine(StringExtension.StrCount(myLongSentence, 'f'));   //0
            WriteLine(StringExtension.StrCount(myLongSentence, '('));   //115
            WriteLine(StringExtension.StrCount(myLongSentence, '\n'));  //96
            WriteLine(StringExtension.StrCount(myLongSentence, ' '));   //172
            */

            /*//Ex4
            int[] someArray = INTArrayExtension.InitArray(10);
            someArray.PrintArray();

            someArray.SortByAscending();
            someArray.PrintArray();
            */

            /*//Ex5
            Point p1 = new(5, 6, 4);
            Point p2 = new(11.1, 2, 0);
            Point p3 = new(11.1, 2, 0);
            Point.Test(p1, p2, p3);
            */

            //Ex6
            ICharacter superUnicorn = new Unicorn("superUnicorn", 1999.99, .5, 200);
            ICharacter megaUnicorn = new Unicorn("megaUnicorn", 1555.55, .7, 300);
            CharactersFighting(superUnicorn, megaUnicorn);
        }

        private static void CharactersFighting(ICharacter Unicorn1, ICharacter Unicorn2)
        {
            int round = 0;
            while (Unicorn1.Health > 0 && Unicorn2.Health > 0)
            {
            Start:
                if (round == 0)
                {
                    string? _unicDefend1, _unicDefend2;
                    Intro(Unicorn1, Unicorn2, out _unicDefend1, out _unicDefend2);

                    if (double.TryParse(_unicDefend1, out double unicDefend1) && double.TryParse(_unicDefend2, out double unicDefend2))
                        round = DefendSetup(Unicorn1, Unicorn2, round, unicDefend1, unicDefend2);
                    else
                    {
                        WriteLine("Some first defend of unicorns didn't parsed. Enter again.");
                        goto Start;
                    }
                }

                ProtectionReset(Unicorn1, Unicorn2, round);

                WriteLine($"\nRound {round}\nSelect distance: ");
                string _specDistance = ReadLine();

                if (!double.TryParse(_specDistance, out double specDistance) || specDistance == 0)
                {
                    WriteLine("Distance to attack didn't parsed. Enter again.");
                    goto Start;
                }
                else
                    Attacks(ref Unicorn1, ref Unicorn2, ref round, specDistance);
            }
            WinnerSelector(Unicorn1, Unicorn2);
        }

        //все декомпозував по методах бо "гарним тоном" є коли метод (в даному випадку CharactersFighting) поміщається "на 1 екрані"
        private static void Intro(ICharacter Unicorn1, ICharacter Unicorn2, out string? _unicDefend1, out string? _unicDefend2)
        {
            WriteLine(Unicorn1);
            WriteLine(Unicorn2);
            Write("\nFor the first => Hello dear Unicorns!\n" +
                  "In first round u can choose first hit defend. \n" +
                  $"{Unicorn1.Name} defend: ");
            _unicDefend1 = ReadLine();
            Write($"{Unicorn2.Name} defend: ");
            _unicDefend2 = ReadLine();
        }

        private static void WinnerSelector(ICharacter Unicorn1, ICharacter Unicorn2)
        {
            if (Unicorn1.Health <= 0)
                WriteLine($"{Unicorn2.Name} wins! Congrat!");
            else if (Unicorn2.Health <= 0)
                WriteLine($"{Unicorn1.Name} wins! Congrat!");
            else
                WriteLine("Draw!");
        }

        private static int DefendSetup(ICharacter Unicorn1, ICharacter Unicorn2, int round, double unicDefend1, double unicDefend2)
        {
            Unicorn1.Defend(unicDefend1);
            Unicorn2.Defend(unicDefend2);
            round++;
            return round;
        }

        private static void Attacks(ref ICharacter Unicorn1, ref ICharacter Unicorn2, ref int round, double specDistance)
        {
            Write($"{Unicorn1.Name} Attacks! -> ");
            Unicorn1.Attack(ref Unicorn2, specDistance);
            Write($"{Unicorn2.Name} Attacks! -> ");
            Unicorn2.Attack(ref Unicorn1, specDistance);
            round++;
        }

        private static void ProtectionReset(ICharacter Unicorn1, ICharacter Unicorn2, int round)
        {
            if (round == 2) // обнуляємо захист. Я розумію що це можна було зробити точно якось краще,
                            // але я роблю це пізно і вже лінь)
            {
                Unicorn1.Defend(1);
                Unicorn2.Defend(1);
            }
        }
        
    }

    #region Ex1_L10
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
                WriteLine("Enter any operation (+ - * / % pow or 0 for exit):");
                string sign = ReadLine();
                switch (sign)
                {
                    case "0": end = true; break;
                    case "+": Add(); break;
                    case "-": Sub(); break;
                    case "*": Mult(); break;
                    case "/": Div(); break;
                    case "%": Rest(); break;
                    case "pow": MyPow(); break;
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

        static void Div() =>
            WriteLine((b != 0) ? $"{a}/{b}={Round(a / b, 3)}" : "b can't = 0");

        static void Rest() =>
            WriteLine((b != 0) ? $"{a}%{b}={Round(a % b, 3)}" : "b can't = 0");

        static void MyPow() =>
            WriteLine($"{a}^{b}={Round(Pow(a, b), 3)}");
    }
    #endregion

    #region Ex2_L10
    static class Convector
    {
        static string? _arg;
        static double arg;
        static bool end = false;
        public static void Conversion()
        {
            while (end == false)
            {
                while (true)
                {
                    Write("Enter argument to convert: ");
                    _arg = ReadLine();

                    if (double.TryParse(_arg, out arg))
                        break;
                    WriteLine("arg wasn't parsed. Plz enter again");
                }
            Start:
                WriteLine("\nChoose 1 - CelsiusToFahrenheit or 2 - FahrenheitToCelsius or 0 for exit):");
                string sign = ReadLine();
                switch (sign)
                {
                    case "0": end = true; break;
                    case "1": CelsiusToFahrenheit(arg); break;
                    case "2": FahrenheitToCelsius(arg); break;
                    default:
                        WriteLine("Operation unfound. Plz enter else sign from existing:\n" +
                            "1, 2 or 0 for exit");
                        goto Start;
                }
            }
        }

        // я зробив double змінну на вході бо так простіший запис методу і не потрібно дублювати конвертування.
        // також залишив методи публічними щоб можна було ними скористатися напряму.
        public static void CelsiusToFahrenheit(double temperatureCelsius) =>
            WriteLine($"{temperatureCelsius}°C to °F={Round(temperatureCelsius * 9 / 5 + 32, 3)}°F");

        public static void FahrenheitToCelsius(double temperatureFahrenheit) =>
            WriteLine($"{temperatureFahrenheit}°F to °C={Round((temperatureFahrenheit - 32) / (9 / 5), 3)}°C");

    }
    #endregion

    #region Ex3_L10
    static class StringExtension
    {
        public static int StrCount(string sentence, char startLetter)
        {
            var length = sentence.Length;
            var counter = 0;
            var toggle = false;
            for (int i = 0; i < length; i++)
            {
                toggle = (toggle == true || sentence[i] == startLetter);

                if (toggle == true)
                    counter++;
            }
            // якщо б в завданні було сказано без пробілів то їх можна було б просто не враховувати.
            // звісно це все можна запихнути в 1 строку на LINQ разом з перевіркою на пробіл, враховуючи чи ні регістр і тд)
            counter = sentence.SkipWhile(x => x != startLetter).Where(e => !char.IsWhiteSpace(e)).Count();
            if (counter == 0)
                WriteLine("Here is no letter u want to start from");
            return counter;
        }
    }
    #endregion

    #region Ex4_L10
    static class INTArrayExtension
    {
        static Random rnd = new();
        public static int[] SortByAscending(this int[] inputArray)
        {
            //return inputArray.Select(e=>e).OrderBy(e=>e).ToArray();
            int length = inputArray.Length;
            for (var i = 1; i < length; i++)
                for (var j = 0; j < length - i; j++)
                    if (inputArray[j] > inputArray[j + 1])
                        Swap(ref inputArray[j], ref inputArray[j + 1]);
            return inputArray;

            static void Swap(ref int p1, ref int p2) => (p2, p1) = (p1, p2); // саме IDE пропонує tuple)
            // до речі цікаво що можна створити статичний метод в статичному методі і все коректно працює
        }
        public static void PrintArray(this int[] array)
        {
            WriteLine();
            foreach (var item in array)
                Write($"{item} ");
            WriteLine();
        }

        internal static int[] InitArray(int v)
        {
            //return new int[v].Select(e => e = rnd.Next(1, 100)).ToArray();
            int[] newArray = new int[v];
            for (int i = 0; i < v; i++)
                newArray[i] = rnd.Next(1, 100);
            return newArray;
        }
    }
    #endregion

    #region Ex5_L10
    class Point
    {
        private static int HashCounter = 0;
        private double x, y, z;

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            HashCounter += 1000;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }

        public static Point operator +(Point p1, Point p2) => new(p1.x + p2.x, p1.y + p2.y, p1.z + p2.z);
        public static Point operator -(Point p1, Point p2) => new(p1.x - p2.x, p1.y - p2.y, p1.z - p2.z);
        public static Point operator *(Point p1, Point p2) => new(p1.x * p2.x, p1.y * p2.y, p1.z * p2.z);
        public static Point operator /(Point p1, Point p2) =>
            new(p1.x / ((p2.x != 0) ? p2.x : 1), p1.y / ((p2.y != 0) ? p2.y : 1), p1.z / ((p2.z != 0) ? p2.z : 1));
        public static Point operator ++(Point point) => new(++point.x, ++point.y, ++point.z);
        public static Point operator --(Point point) => new(--point.x, --point.y, --point.z);

        public override string ToString() => $"x: {X}, y: {Y}, z: {Z}";
        public override bool Equals(object? obj) => X == (obj as Point).X && Y == (obj as Point).Y && Z == (obj as Point).Z;
        public override int GetHashCode() => HashCounter;
        public static void Test(Point p1, Point p2, Point p3)
            => WriteLine($"p1 = {p1}\n" +
                $"p2 = {p2}\n" +
                $"p3 = {p3}\n" +
                $"p3.GetHashCode() => {p3.GetHashCode()}\n" +
                $"p1 + p2 = {p1 + p2}\n" +
                $"p1 - p2 = {p1 - p2}\n" +
                $"p1 * p2 = {p1 * p2}\n" +
                $"p1 / p2 = {p1 * p2}\n" +
                $"++p1 = {++p1}\n" +
                $"--p1 = {--p1}\n" +
                $"p2 == p3 => {p2.Equals(p3)}\n"
                );
        // ToString ми й так використовуємо коли виводим точки як результати
        // GetHashCode викликав на початкую бо кожен раз коли ми виводими результатом нову точку -> номер росте
    }
    #endregion

    #region Ex6_forL9
    interface ICharacter
    {
        string Name { get; }
        double Health { get; set; }
        double Agility { get; }
        double Strength { get; }
        void Attack(ref ICharacter aim, double distance);
        void Defend(double damage);
    }
    class Unicorn : ICharacter
    {
        static Random rnd = new();
        private bool defenderSwith = true;
        private double tmpDamage = 0;

        /// <summary>
        /// health=> [1000;1000000], agility=> [0;1], strength=> [1;10000]
        /// </summary>
        public Unicorn(string name, double health, double agility, double strength)
        {
            Name = name;
            Health = (health is >= 1000 and <= 1000000) ? health : 1000;
            Agility = (agility is >= 0 and <= 1) ? agility : 0;
            Strength = (strength is >= 1 and <= 10000) ? strength : 1;
        }

        public double Health { get; set; }

        public double Agility { get; }

        public double Strength { get; }

        public string Name { get; }

        //я чесно не зрозумів нащо там distance, але уявимо що чим вона вище
        //тим атака більше падає допоки не буде 0-ва або не перекриватиметься agility - ймовірність парирування
        //також очевидним є те, що тут можна напридумувати безліч перевірок, але зображу лише дууууже базові.
        public void Attack(ref ICharacter aim, double distance)
        {

            if (distance > 0)
            {
                double hit = (aim.Agility >= rnd.NextDouble() ? 0 : Strength) *
                ((distance > 100) ? -10000 : 1 - distance / 100) - tmpDamage;

                if (hit > 0)
                    aim.Health -= hit;
                Write((hit <= 0) ? "MISS\n" : $"Hit: {Round(hit)}, opponent health: {((aim.Health > 0) ? Round(aim.Health) : 0)}\n");
            }
            else
                WriteLine("Distance can't be less than 0");
        }

        //взагалі не зрозумів нащо). Припустим якщо хтось з них викличе цей метод
        //тоді від дасть захист на наступний удар на вказану кількість damage.
        //Також дозволив це лиш раз.
        public void Defend(double damage)
        {
            tmpDamage = defenderSwith ? damage : 0;
            defenderSwith = false;
        }
        public override string ToString()
            => $"{Name}: Health: {Round(Health, 2)}, " +
            $"Lucky: {Round(Agility, 2)}, " +
            $"Strenght: {Round(Strength, 2)}";
    }
    #endregion
}