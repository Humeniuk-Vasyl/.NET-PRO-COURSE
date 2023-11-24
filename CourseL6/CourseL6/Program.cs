using static System.Console;
using static System.Math;
namespace CourseL6
{
    class Program
    {
        static Random rnd = new();

        public static void Main()
        {
            //Ex1_L6();
            //Ex2_L6();
            //Ex3_L6();
            //Ex4_L6();
            //Ex5_L6();
            //Ex6_L6();
            //Ex7_L6();
            //Ex8_L6();
            //Ex9_L6();
            //Ex10_L6_forL5();
            Ex11_L6_forL5();
        }

        private static void Ex1_L6()
        {
            var array = new int[5];
            //array = array.Select(i => i = rnd.Next(1,10)).ToArray(); //LINQ way)
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(1, 10);
            foreach (var item in array)
                Write($"{item} ");
        }

        private static void Ex2_L6()
        {
            var array = new int[5];
            var length = array.Length; // щоб кожен раз не викликати .length, хоча власне тут це не важливо
            for (int i = length - 1; i >= 0; i--)
                array[i] = rnd.Next(1, 10);
            foreach (var item in array)
                Write($"{item} ");
        }

        private static void Ex3_L6()
        {
            string[] A = new string[4], B = new string[4];
            var length = A.Length;
            //A = A.Select(s => s = ReadLine()).ToArray();
            for (int i = 0; i < length; A[i] = ReadLine(), i++)
                Write($"Enter new string for A[{i}]: ");
            for (int i = length - 1, t = 0; i >= 0; i--, t++)
                B[i] = A[t];
            //B = A.Reverse().ToArray();
            foreach (var item in B)
                Write(item);
        }
        
        #region Ex4_L6
        private static void Ex4_L6() =>
            WriteLine(MethodForEx4("Vasyl"));

        private static string MethodForEx4(string word)
        {
            //return new string(word.Reverse().ToArray()); //or
            //return new string(word.ToCharArray().Reverse().ToArray()); // or
            var stringInArray = word.ToCharArray();
            var newWord = "";
            var length = word.Length;
            for (int i = length - 1; i >= 0; i--)
                newWord += stringInArray[i];
            return new string(newWord);
        }
        #endregion

        private static void Ex5_L6()
        {
            string? _start, _end;
            int start, end;
            int[] profits = new int[12];
            for (int i = 0; i < 12; i++) // думаю не проти будете як я генеруватиму прибутки псевдо-випадково)
                profits[i] = rnd.Next(100, 1000);
            Write("Profits: ");
            foreach (var profit in profits)
                Write($"{profit} ");
            WriteLine();
            while (true)
            {
                Write($"Plz enter range of months.\nStart: ");
                _start = ReadLine();
                Write("& End: ");
                _end = ReadLine();
                if (int.TryParse(_start, out start) && int.TryParse(_end, out end) && start > 0 && end > start && end <= 12)
                    break;
                WriteLine("Start or end month wasn't parsed, <= 0,end < start or end>12. Plz enter again");
            }
            int max = 0;
            int maxI = 0;
            for (int i = start - 1; i <= end - 1; i++)
                if (profits[i] > max)
                {
                    max = profits[i];
                    maxI = i;
                }
            WriteLine($"Max profits from [{start},{end}]: {max}. Month: {maxI + 1}");
        }

        private static void Ex6_L6()
        {
            string? _n;
            int n;

            while (true)
            {
                Write($"Plz enter size of array: ");
                _n = ReadLine();
                if (int.TryParse(_n, out n) && n > 0)
                    break;
                WriteLine("Size wasn't parsed, or <=0. Plz enter again");
            }
            int[] Array = new int[n];
            for (int i = 0; i < n; i++)
                Array[i] = rnd.Next(1, 100);
            Write("Your array: ");
            foreach (var num in Array)
                Write($"{num} ");
            WriteLine();
            int max = 0, min = int.MaxValue, sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (Array[i] > max)
                    max = Array[i];
                if (Array[i] < min)
                    min = Array[i];
                sum += Array[i];
                if ((Array[i] % 2 != 0))
                    Write($"Odd: {Array[i]} ");
            }
            double mean = (double)sum / n;
            WriteLine($"\nMax value: {max}\n" +
                $"Min value: {min}\n" +
                $"Sum: {sum}\n" +
                $"Mean: {Round(mean, 2)}");
        }

        #region Ex7_L6
        private static void Ex7_L6()
        {
            int index, count, n = rnd.Next(5, 20), tmpChecker;
            string? _index, _count;
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = rnd.Next(100, 1000);
            Write("Start array: ");
            foreach (var num in array)
                Write($"{num} ");
            WriteLine();
            while (true)
            {
                Write($"Plz enter index to start from.\nIndex: ");
                _index = ReadLine();
                Write("& count of elements: ");
                _count = ReadLine();

                if (!int.TryParse(_index, out index) || !int.TryParse(_count, out count) || index <= 0 || count <= 0)
                {
                    WriteLine("Index or count wasn't parsed, index <= 0 or end<=0. Plz enter correct input again.");
                    continue;
                }

                tmpChecker = n - index;

                if (count - 1 > tmpChecker)
                {
                    WriteLine("Not enough elements. Check index & count");
                    continue;
                }
                break;
            }
            int[] subArray = MethodForEx7(array, index - 1, count);
            WriteLine("Sub array:");
            foreach (var num in subArray)
                Write($"{num} ");
        }

        private static int[] MethodForEx7(int[] array, int index, int count)
        {
            int[] subArray = new int[count];
            for (int i = index, k = 0; k < count; i++, k++)
                subArray[k] = array[i];
            return subArray;
        }
        #endregion

        #region Ex8_L6
        private static void Ex8_L6()
        {
            int n = rnd.Next(5, 20);
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = rnd.Next(1, 100);
            Write("Your array: ");
            foreach (var num in array)
                Write($"{num} ");
            WriteLine();

            int value;
            string? _value;
            while (true)
            {
                Write($"Plz add value for new array: ");
                _value = ReadLine();
                if (int.TryParse(_value, out value))
                    break;
                WriteLine("value wasn't parsed. Plz enter again");
            }
            var newArray = MethodForEx8(array, value);
            Write("New array: ");
            foreach (var num in newArray)
                Write($"{num} ");
        }

        private static int[] MethodForEx8(int[] array, int value)
        {
            int length = array.Length + 1;

            var newArray = new int[length];
            newArray[0] = value;
            for (int i = 1; i < length; i++)
                newArray[i] = array[i - 1];
            return newArray;
        }
        #endregion

        private static void Ex9_L6()
        {
            //int n = 3;
            int n = 10;

            var bigArray = new int[n, n];
            var rowsSum = new int[n];
            var colProduct = new long[n]; // uses long qaz of -product-
            int maxDiagonalElm = 0;
            int length = n;
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    bigArray[i, j] = rnd.Next(10, 100);

            for (int i = 0; i < length; i++)
                colProduct[i] = 1;
            for (int i = 0; i < length; i++, WriteLine())
                for (int j = 0; j < length; j++)
                {
                    if (i == j && bigArray[i, j] > maxDiagonalElm)
                        maxDiagonalElm = bigArray[i, j];
                    rowsSum[i] += bigArray[i, j];
                    colProduct[j] *= bigArray[i, j];
                    Write($"{bigArray[i, j]} ");
                }

            //Results
            WriteLine("sum of elements in row:");
            foreach (var num in rowsSum)
                Write($"{num} ");
            WriteLine("\nproduct of elements in column:");
            foreach (var num in colProduct)
                Write($"{num} ");
            WriteLine($"\nMax main-diagonal element: {maxDiagonalElm}");
        }

        #region Ex10_L6_forL5
        private static void Ex10_L6_forL5()
        {
            string? _n;
            double n;
            while (true)
            {
                Write($"Plz enter any meters num > 0: ");
                _n = ReadLine();
                if (double.TryParse(_n, out n) && n > 0)
                    break;
                WriteLine("n wasn't parsed, or <=0. Plz enter again");
            }
            MethodForEx10(n);

        }
        private static void MethodForEx10(double meters)
        {
            //WriteLine($"{meters} meters = {meters * 10} ");
            MethodForEx10(meters, Round(meters * 10, 4));
        }

        private static void MethodForEx10(double meters, double centimeters)
        {
            //WriteLine($"{centimeters} centimeters = {centimeters/10} millimeters");
            MethodForEx10(meters, centimeters, Round(centimeters * 10, 4));
        }

        private static void MethodForEx10(double meters, double centimeters, double millimeters)
        {
            //WriteLine($"{meters} meters = {meters/1000} kilometers ");
            MethodForEx10(meters, centimeters, millimeters, Round(meters / 1000, 4));
        }

        private static void MethodForEx10(double meters, double centimeters, double millimeters, double kilometers) =>
            WriteLine($"Your {meters} meters = {centimeters} centimeters, {millimeters} millimeters and {kilometers} kilometers");
        #endregion

        #region Ex11_L6_forL5
        private static void Ex11_L6_forL5()
        {
            int A = rnd.Next(1, 100), B = rnd.Next(1, 100);
            WriteLine($"A: {A}, B: {B}");
            MethodForEx11(A, B, A > B);
        }

        private static void MethodForEx11(int a, int b, bool way)
        {
            //В завданні не сказано що необхідно використати лише 1 рекурсивний метод однак зроблю так)
            if (way)
            {
                if (b > a)
                    return;
                Write($"{b} ");
                MethodForEx11(a, ++b, way);
            }
            else
            {
                if (a > b)
                    return;
                Write($"{a} ");
                MethodForEx11(++a, b, way);
            }
        }
        #endregion
    }
}