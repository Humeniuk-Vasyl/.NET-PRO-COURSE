using static System.Console;

namespace CourseL22
{
    public class Program
    {
        public static void Main()
        {
            //Ex1
            //Ex1_L22Class.Print1();
            //Ex1_L22Class.Print2(); //Compiler error cause IsError attr is true

            Programmer Alfa = new() { Name = "Alfa" };
            Manager Vasyl = new() { Name = "Vasyl" };
            Director Anton = new() { Name = "Anton" };
            EtcMember Uzuf = new() { Name = "Uzuf" };

            AccessControl.AccessProtectedSection(Alfa);
            AccessControl.AccessProtectedSection(Vasyl);
            AccessControl.AccessProtectedSection(Anton);
            AccessControl.AccessProtectedSection(Uzuf);
            // не зовсім впевнений що розв'язок має бути приблизно таким, але в цілому я перевірив
            // доступ до захищеної секції перевіряючи рівень доступу рефлексією та виводячи фідбек.
        }
    }
    public class AccessControl
    {
        public static void AccessProtectedSection(Employee employee)
        {
            // Перевіряємо, чи існує атрибут AccessLevelAttribute для класу сотрудника
            var accessLevelAttribute = (AccessLevelAttribute?)Attribute.GetCustomAttribute(employee.GetType(), typeof(AccessLevelAttribute));

            if (accessLevelAttribute != null)
            {
                // Перевіряємо рівень доступу
                WriteLine($"{employee.GetType().Name} {employee.Name} have access level {accessLevelAttribute.GetAccessLevel}.");

                if (accessLevelAttribute.GetAccessLevel >= 2)
                    ProtectedSection(employee);
                else
                    WriteLine($"Access denied for {employee.GetType().Name} {employee.Name}.");
            }
            else
                WriteLine($"Access level not defined for {employee.GetType().Name} {employee.Name}.");
        }

        private static void ProtectedSection(Employee employee) => WriteLine($"protection section called by {employee.Name}");
    }

    [Obsolete("Non more ussable!")]
    public static class Ex1_L22Class
    {
        [Obsolete("Temp1")]
        public static void Print1() => WriteLine("Temp1");

        [Obsolete("Temp2", true)]
        public static void Print2() => WriteLine("Temp2");
    }

    public class Employee
    {
        public string? Name { get; set; }
    }

    public class Programmer : Employee { }

    [AccessLevel(2)]
    public class Manager : Employee { }

    [AccessLevel(3)]
    public class Director : Employee { }

    public class EtcMember : Employee { }
}