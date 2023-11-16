using static System.Console;

namespace IntroduceL1
{
    public class Program
    {
        public static void Main()
        {
            //Ex1_L1();
            //Ex2_L1();
            //Ex3_L1();
            //Ex4_L1();
            //Ex5_L1();
            //Ex6_L1();
            //Ex8_L1();
            Ex9_L1();
        }
        // Більшість прикладів вводів потрібно поміщати в try-catch але ця тема буде потім
        private static void Ex1_L1()
        {
            Write("Enter meters: ");
            double m = double.Parse(ReadLine());
            Write($"{m}m is equal to {m*100}cm");
        }
        private static void Ex2_L1()
        {
            double pi = Math.PI;
            Write("Enter radius: ");
            double r = double.Parse(ReadLine());
            double square = pi * Math.Pow(r, 2);  //or better pi * r * r
            Write($"r: {r}, square: {Math.Round(square,4)}");
        }
        private static void Ex3_L1()
        {
            Write("Enter cated 1: ");
            double a = double.Parse(ReadLine());
            Write("Enter cated 2: ");
            double b = double.Parse(ReadLine());
            Write($"Hypotenuse: {Math.Round(Math.Sqrt(a*a + b*b),4)}");
        }
        private static void Ex4_L1()
        {
            Write("Enter angle: ");
            double angle = double.Parse(ReadLine());
            Write($"sin(angle): {Math.Sin(angle)}");
        }
        private static void Ex5_L1()
        {
            Write("Enter a: ");
            int a = int.Parse(ReadLine());
            Write("Enter b: ");
            int b = int.Parse(ReadLine());

            Write($"a+b: {a+b}\n" +
                $"a-b: {a-b}\n" +
                $"a*b: {a * b}\n" +
                $"a/b: {a / b} \n" +
                $"a%b: {a % b} \n" +
                $"a++: {a++} \n" +
                $"b++: {b++} \n" +
                $"a-- {a--} \n" + // first output, then operation
                $"b-- {b--}\n" +
                $"--a {--a} \n" + // first operation, then output
                $"--b {--b}"
                );
        }
        private static void Ex6_L1()
        {
            Write("Enter price: ");
            double price = double.Parse(ReadLine());
            Write("Enter sale in persent: ");
            double sale = double.Parse(ReadLine());
            Write($"From {price}, {sale}% is: {price*sale/100}");
        }
        private static void Ex8_L1()
        {
            int x = 10, y = 12, z = 3;
            x += y - x++ * z; // -9
            z = --x - y * 5; // -69
            y /= x + 5 % z; //-3
            z = x++ + y * 5; //-24
            x = y - x++ * z; //-195
            Write($"x: {x}\n" +
                $"y: {y}\n" +
                $"z: {z}");
        }
        private static void Ex9_L1()
        {
            Write("Enter radius: ");
            double r = double.Parse(ReadLine());
            Write("Enter height: ");
            double h = double.Parse(ReadLine());
            double S = 2 * Math.PI*r * (r + h);
            double V = Math.PI*r*r*h;
            Write($"Square of cylinder: {Math.Round(S,5)}, volume: {Math.Round(V, 5)}");
        }

    }
}