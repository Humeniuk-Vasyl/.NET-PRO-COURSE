using static System.Console;
using static System.Convert;
using static System.Math;

namespace CourseL13
{
    public class Program
    {
        public static void Main()
        {
            /*//Ex1
            Book<int> book1 = new("SherlockAdvnture", 1000);
            Book<double> book2 = new("C# 10 и .NET 6. Современная кросс-платформенная разработка", 1100.10);
            book1.Show();
            book2.Show();
            */

            /*//Ex2
            var myTVar = MyClass<double>.FactoryMethod();
            */

            //Ex3
            Calculator<double, string> calc1 = new (14.2, "3");
            calc1.Add();
            calc1.Sub();
            calc1.Mult();

            //Ex4
            //DateTime time;
            //DateTime? time;
            DateTime? time = null;
            if (time == null)
            {
                WriteLine("Do something");
            }
            // Ні не являється валідним в початковому варіанті запису, оскільки time ніколи не дорівнюватиме null тобто не Nullable,
            // і навіть якщо написати Datetime? time; всерівно потрібно попередньо ініціалізувати часом чи null
            // якщо це явно не вказати при декларації (якщо я правильно зрозумів питання).
            // Після ініціалізації достукатись до цього if вже вийде.
            
        }
    }

    #region Ex1_L13
    public class Book<T>
    {
        private string? name;
        private T? price;

        public Book(string? name, T price)
        {
            Name = name ?? "";
            Price = price;
        }

        public string? Name { get => name; set => name = value; }

        public T? Price { get => price; set => price = value; }

        public void Show() => WriteLine($"Book {name} -> {price}UAH");
    }

    #endregion

    #region Ex2_L13
    class MyClass<T>
    {
        private static T? myValue;

        private static T? MyValue { get => myValue; set => myValue = value; }

        public MyClass(T? myValue) => MyValue = myValue;

        public static T? FactoryMethod()
        {
            WriteLine($"Your field type: {typeof(T)}");
            return MyValue;
        }
    }
    #endregion

    #region Ex3_L13
    class Calculator<T1,T2>
    {
        public T1? arg1 { get; set; }
        public T2? arg2 { get; set; }

        public Calculator(T1 Arg1, T2 Arg2)
        {
            arg1 = Arg1;
            arg2 = Arg2;
        }

        public void Add() => OpSelector('+');

        public void Sub() => OpSelector('-');

        public void Mult() => OpSelector('*');

        private void OpSelector(char op)
        {
            var res = (op == '+') ? Round(ToDouble(arg1) + ToDouble(arg2))
                : ((op == '-') ? Round(ToDouble(arg1) - ToDouble(arg2), 3) : Round(ToDouble(arg1) * ToDouble(arg2)));
            //така тернарка суто для цього випадку коли мало операцій + на жаль ми не можемо передати конкретно операцію як operator в c#,
            WriteLine($"arg1 {op} arg2: {res}"); 
        }
    }
    #endregion
}