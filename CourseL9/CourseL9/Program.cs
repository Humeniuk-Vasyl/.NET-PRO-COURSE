using static System.Console;

namespace CourseL9
{
    class Program
    {
        public static void Main()
        {
            /*//Ex1
            var book = new Book(); // можна було обійтися без пустих конструкторів але в принципі і так може бути
            var book2 = new Book("Jimmy");
            var book3 = new Book("Owy");
            var book4 = new Book() { Name = "Nani" };
            var journal = new Journal();
            var journal2 = new Journal("journal2");
            var journal3 = new Journal("journal3");

            var Printable = new IPrintable[] {book4, book, journal, book2, book3, journal, journal2, journal3 };
            
            WriteLine("Items in Printable:");
            foreach (var item in Printable)
                item.Print();

            Magazine.PrintMagazines(Printable);
            Book.PrintBooks(Printable);
            */

            /*//Ex2
            Player Player = new("Eminem: Mockingbird");
            var Player_asPlayable = Player as IPlayable;
            Player_asPlayable.Play();
            Player_asPlayable.Pause();
            Player_asPlayable.Play();
            Player_asPlayable.Stop();
            var Player_asRecordable = Player as IRecordable;
            Player_asRecordable.Record();
            Player_asRecordable.Pause();
            Player_asRecordable.Record();
            Player_asRecordable.Stop();
            */

            /*//Ex3
            DocChild docChild = new("Christian Bale");
            docChild.Headline();
            docChild.DocumentContent();
            docChild.Footer();

            var upCastedDocChild = (Document)docChild; // same output
            WriteLine(upCastedDocChild.Name);
            upCastedDocChild.Headline();
            upCastedDocChild.DocumentContent();
            upCastedDocChild.Footer();
            */

            /*//Ex4
            XMLHandler XMLHandler = new();
            XMLHandler.Create("spreadsheet");
            XMLHandler.Change("sss");
            XMLHandler.Open();
            XMLHandler.Save();

            TXTHandler TXTHandler = new("test");
            DOCHandler DOCHandler = new("test");

            var AbstractHandlerArray = new AbstractHandler[] { XMLHandler, TXTHandler, DOCHandler, DOCHandler, TXTHandler, XMLHandler };
            GetAbstractHandlersInfo(AbstractHandlerArray);
            */

            //Ex5
            //я зробив без пустих конструкторів щоб це все трохи пришвидшити
            WorkMan vasyl = new("vasyl", 22, 2000, "DevOps");
            WorkMan roman = new("roman", 21, 2100.20, "PR");
            WorkMan oleh = new("oleh", 28, 4000, "HR");
            WorkMan zhenya = new("zhenya", 25, 3000, "DevOps");

            var employees = new Employee[] { vasyl, roman, oleh, zhenya };

            Director directorRoman = new("Dyad'ko Roman", 35, 10000, employees);
            Director directorAnton = new("Dyad'ko Anton", 30, 11100, new Employee[] {vasyl, roman });

            WriteLine(vasyl.ToString());
            WriteLine(directorRoman.ToString());
            
            new Salary().SalaryInfo(employees); // оскільки поки ми не знаєм поки що таке static
                                                //  - виклик метода через новий екземпляр
            new Salary().RaiseSalary(ref employees, 10); // єдиний варіант який мені збіг на думку це заюзати ref
            new Salary().SalaryInfo(employees);

            WriteLine("\nTests");
            Employee UpcastedVasyl = vasyl;
            WriteLine(UpcastedVasyl.ToString());               //досі як WorkMan
            
            Write((directorRoman as Employee).ToString());     //досі як Director & cast is redundant

            var Greg = new Employee("Greg", 20, 2000);
            WriteLine(Greg.ToString());

        }

        /// <summary>
        /// Gives u info about all inherited to AbstractHandler instances
        /// </summary>
        private static void GetAbstractHandlersInfo(AbstractHandler[] AbstractHandlerArray)
        {
            foreach (var item in AbstractHandlerArray)
                WriteLine($"Info about {item.Name}.{item.Format}");
        }
    }
    #region Ex1_L9
    interface IPrintable
    {
        string Name { get; set; }
        void Print();
    }
    class Book : IPrintable
    {
        public string? Name { get; set; }
        public Book() => Name = "no book name";
        public Book(string? name) => Name = name;

        public void Print() => WriteLine($"book: \"{Name}\"");

        public static void PrintBooks(IPrintable[] printable)
        {
            WriteLine("\nPrintBooks output:");
            for (int i = 0; i < printable.Length; i++)
            {
                (printable[i] as Book)?.Print(); // в даному випадку звичайний upcast викличе exception
                /*Book? book = printable[i] as Book;
                printable[i] = book;
                printable[i]?.Print();*/
            }
        }
    }
    class Journal : IPrintable
    {
        public string? Name { get; set; }

        public Journal() => Name = "no journal name";

        public Journal(string? name) => Name = name;

        public void Print() => WriteLine($"journal: \"{Name}\"");
    }
    class Magazine : IPrintable
    {
        public string? Name { get; set; }

        public void Print() => WriteLine($"{Name}");

        public static void PrintMagazines(IPrintable[] printable)
        {
            WriteLine("\nPrintMagazines output:");
            for (int i = 0; i < printable.Length; i++)
                (printable[i] as Journal)?.Print();
        }
    }
    #endregion

    #region Ex2_L9
    interface IPlayable
    {
        string Sound { get; set; }
        void Play();

        void Pause();

        void Stop();
    }
    interface IRecordable //мабуть правильно recordable)
    {
        string Sound { get; set; }
        void Record();

        void Pause();

        void Stop();
    }
    class Player : IPlayable, IRecordable
    {
        public Player(string sound) => Sound = sound;

        public string Sound { get; set; }

        void IPlayable.Play() => WriteLine($"IPlayable sound <{Sound}> PLAYS");

        void IRecordable.Record() => WriteLine($"IRecordable sound <{Sound}> RECORD");
        //я не дуже впевнений що правильно зрозумів завдання, але є 2 методи Play і Record
        //реалізація яких є різною для 2 інтерфейсів і по 2 методи Pause і Stop суть яких однакова,
        //і при цьому вони обов'язкові для імплементаціями 2-ма інтерфейсами.

        public void Pause() => WriteLine($"Sound <{Sound}> pauses");

        public void Stop() => WriteLine($"Sound <{Sound}> stops");
    }
    #endregion

    #region Ex3_L9
    abstract class Document
    {
        public string Name { get; set; }

        protected Document(string name) => Name = name;

        public abstract void Headline();

        public abstract void DocumentContent();

        public abstract void Footer();
    }
    class DocChild : Document
    {
        private readonly string name;

        public DocChild(string Name) : base(Name) => name = Name;

        public override void Headline() => WriteLine($"Some {name} topic...");

        public override void DocumentContent() => WriteLine($"Some {name} body...");

        public override void Footer() => WriteLine($"Some {name} footer...");
    }
    #endregion

    #region Ex4_L9
    abstract class AbstractHandler
    { //як варіант залишив 2 методи virtual і 2 -> abstract
        protected AbstractHandler(string name, string format)
        {
            Name = name;
            Format = format;
        }

        public string Name { get; set; }

        public string Format { get; }

        public virtual void Create(string name) => WriteLine($"{Format} document with name: {Name = name} created");

        public virtual void Change(string newName) => WriteLine($"Name: {Name} will change to: {Name = newName}");

        public abstract void Open();

        public abstract void Save();
    }

    class XMLHandler : AbstractHandler
    {
        public XMLHandler() : base("", "XML") { }

        public XMLHandler(string Name) : base(Name, "XML") { }

        public override void Create(string name)
        {
            WriteLine($"Special TODO for XML...\n");
            base.Create(name);
        } // я не придумав як зобразити створення по іншому, але думаю в цьому контексті це не так принципово

        public override void Change(string newName)
        {
            WriteLine($"Special Change TODO for XML...");
            base.Change(newName);
        }

        public override void Open() => WriteLine($"Special Open TODO for XML...");

        public override void Save() => WriteLine($"Special Save TODO for XML...");
    }

    class TXTHandler : AbstractHandler
    {
        public TXTHandler() : base("", "TXT") { }

        public TXTHandler(string Name) : base(Name, "TXT") { }

        public override void Create(string name)
        {
            WriteLine($"Special TODO for TXT...\n");
            base.Create(name);
        }

        public override void Change(string newName)
        {
            WriteLine($"Special Change TODO for TXT...");
            base.Change(newName);
        }

        public override void Open() => WriteLine($"Special Open TODO for TXT...");

        public override void Save() => WriteLine($"Special Save TODO for TXT...");
    }

    class DOCHandler : AbstractHandler
    {
        public DOCHandler() : base("", "DOC") { }

        public DOCHandler(string Name) : base(Name, "DOC") { }

        public override void Create(string name)
        {
            WriteLine($"Special TODO for DOC...\n");
            base.Create(name);
        }

        public override void Change(string newName)
        {
            WriteLine($"Special Change TODO for DOC...");
            base.Change(newName);
        }

        public override void Open() => WriteLine($"Special Open TODO for DOC...");

        public override void Save() => WriteLine($"Special Save TODO for DOC...");
    }
    #endregion

    /*#region Ex4_L9_elseVar
    //в завданні не сказано що це має бути абстрактний клас отже завдання можна було зробити так:
    class AbstractHandler
    {
        protected AbstractHandler(string name, string format)
        {
            Name = name;
            Format = format;
        }

        public string Name { get; set; }

        public string Format { get; }

        public void Create(string name) =>
            WriteLine($"{Format} item with name: {Name = name} created");

        public void Change(string newName) =>
            WriteLine($"Name: {Name} will change to: {Name = newName}");

        public void Open() => WriteLine($"{Name}.{Format} opened");

        public void Save() => WriteLine($"{Name}.{Format} saved");
    }

    // щоправда такий варіант підходить якщо б реалізація цих методів було б принципово однакова, що звісно що не так)
    class XMLHandler : AbstractHandler
    {
        public XMLHandler() : base("", "XML") { }

        public XMLHandler(string Name) : base(Name, "XML") { }
    }

    class TXTHandler : AbstractHandler
    {
        public TXTHandler() : base("", "TXT") { }

        public TXTHandler(string Name) : base(Name, "TXT") { }
    }

    class DOCHandler : AbstractHandler
    {
        public DOCHandler() : base("", "DOC") { }

        public DOCHandler(string Name) : base(Name, "DOC") { }
    }
    #endregion
*/

    #region Ex5_forL8
    class Employee
    {
        public string? Name { get;}

        protected int Age { get; set; }

        public double Salary { get; set; }

        public Employee(string? name, int age, double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public override string ToString() =>
            "\nInfo:\n" +
                $"Name: {Name}\n" +
                $"Age: {Age}\n" +
                $"Salary: {Salary}\n";
    }
    class WorkMan : Employee 
    {
        private string? department;

        public WorkMan(string name, int age, double salary, string? department) : base(name, age, salary) => 
            Department = department;

        public string? Department { get => department; set => department = value; }

        public override string ToString() =>
                base.ToString() +
                $"And department: {department}\n";
    }

    class Director : Employee 
    {
        Employee[]? employees;

        internal Employee[]? Employees { get => employees; set => employees = value; }

        public Director(string name, int age, double salary, Employee[]? employees) : base(name, age, salary) => 
            Employees = employees;

        public override string ToString()
        {
            string employeesInfo = "And employees:";

            foreach (var employee in employees)
                employeesInfo += employee.ToString();
            return base.ToString() +'\n' + employeesInfo + '\n';
        }       
    }

    class Salary
    {
        public void RaiseSalary(ref Employee[] employees, int percent)
        {
            foreach (var employee in employees)
                employee.Salary += employee.Salary * (percent/100.0);
        } //хоча компілятор й сам пропонує робити статичним)

        public void SalaryInfo(Employee[] employees)
        {
            WriteLine("\nSalary Info:");
            foreach (var employee in employees)
                Write($"employee {employee.Name} - <{employee.Salary}> ");
        }
    }
    #endregion
}