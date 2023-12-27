using static System.Console;

namespace CourseL11
{
    class Program
    {

        static void Main()
        {
            /*//Ex1
            Notebook myNote = new("XiaomiEBook", "Xiaomi", 2000); 
            WriteLine(myNote);
            myNote.PrintNotebook();
            */

            /*//Ex2
            Train.Train_Test();
            */

            /*//Ex3
            MyClass myClass = new("Not changed");
            MyStruct myStruct = new("Not changed");
            ClassTaken(myClass);
            WriteLine(myClass);         //Changed
            StructTaken(myStruct);
            WriteLine(myStruct);        //Not changed, оскільки ми працюємо з value змінною myStruct
            StructTaken(ref myStruct);
            WriteLine(myStruct);        //Changed
            */

            /*//Ex4
            PrintExtension.TestPrint();
            */

            //Ex5
            Accauntant acc = new("Oleh", (Post)10);
            acc.AskForBonus(acc.Post, 9);           
            WriteLine(acc); //Name: Oleh, Post : CEO, premium: False
            acc.AskForBonus(acc.Post, 11);
            WriteLine(acc); //Name: Oleh, Post: CEO, premium: True
            Accauntant worker = new("Maks", Post.Frontend_Dev);
            worker.AskForBonus(worker.Post, 50);
            WriteLine(worker);

        }

        #region For_Ex3_L11
        //For Ex3
        static void ClassTaken(MyClass myClass) => myClass.change = "Changed";

        static void StructTaken(MyStruct myStruct) => myStruct.change = "Changed";

        static void StructTaken(ref MyStruct myStruct) => myStruct.change = "Changed"; // цікаво що поліморфізм може й так працювати,
                                                                                       // виключно добавивши ref)
        #endregion
    }

    #region Ex1_L11
    struct Notebook
    {
        public string? Model { get; set; }
        public string? Producer { get; set; }
        public double Price { get; set; }

        public Notebook(string? model, string? producer, double price)
        {
            Model = model;
            Producer = producer;
            Price = price;
        }

        public readonly void PrintNotebook() =>
            WriteLine($"model: {Model}, Producer: {Producer}, Pricer: {Price}UAH");

        public override readonly string ToString() =>
            $"model: {Model}, Producer: {Producer}, Pricer: {Price}UAH";
    }
    #endregion

    #region Ex2_L11
    struct Train
    {
        static readonly Random rnd = new();
        public string? DestinationName { get; init; }
        public int Index { get; set; }
        public TimeOnly DepartureTime { get; set; }

        public Train(string? destinationName, int index, TimeOnly departureTime)
        {
            DestinationName = destinationName;
            Index = index;
            DepartureTime = departureTime;
        }

        public override readonly string ToString() =>
            $"model: {DestinationName}, Index: {Index}, Departure time: {DepartureTime}";

        public static Train[] Inits()
        {
            Train[] myTrains = new Train[5];
            for (int i = 0; i < 5; i++)
                myTrains[i] = new Train($"Destinantion{i + 1}", rnd.Next(1000, 9999), new TimeOnly(10 + i, 30 + i)); // це суто для прикладу
            return myTrains;
        }

        public static void PrintTrains(Train[] trains)
        {
            WriteLine("All info:");
            foreach (Train t in trains)
                WriteLine(t);
        }

        public static void Train_Test()
        {
            Train[] myTrains = Inits();

            while (true)
            {
                PrintTrains(myTrains);
            Start:
                WriteLine("Enter num of train from existing or 0 for exit");
                if (!int.TryParse(ReadLine(), out int selectedNum))
                {
                    WriteLine("Num didn't parsed!");
                    goto Start;
                }
                else if (selectedNum == 0)
                {
                    Clear();
                    WriteLine("exit. by");
                    break;
                }

                Train tmpTrain = new();

                foreach (var train in myTrains)
                    if (train.Index == selectedNum)
                        tmpTrain = train;

                if (tmpTrain.Index == 0)
                    WriteLine("Selected num doesn't exist.");
                else
                    WriteLine($"{tmpTrain}\n");
                goto Start;
            }
        }
    }
    #endregion

    #region Ex3_L11
    class MyClass
    {
        public string? change;

        public MyClass(string? change) => this.change = change;

        public override string ToString() => change;
    }

    struct MyStruct
    {
        public string? change;

        public MyStruct(string? change) => this.change = change;

        public override string ToString() => change;

    }
    #endregion

    #region Ex4_L11
    static class PrintExtension
    {
        private static void Print(string stroka, int color)
        {
            ForegroundColor = (ConsoleColor)color;
            WriteLine(stroka);
        }

        internal static void TestPrint()
        {
            while (true)
            {
            Start:
                WriteLine("Enter stroke:");
                var stroke = ReadLine();
                WriteLine("Enter new color between [0;15]");
                if (!int.TryParse(ReadLine(), out int color) || color < 0 || color > 15 || stroke == "")
                {
                    WriteLine("stroke empty or color didn't parsed or color isn't between [0;15].");
                    goto Start;
                }
                Print(stroke, color);
                break;
            }
        }
    }
    #endregion

    #region Ex5_L11
    class Accauntant
    {
        private bool premium;
        
        public string Name { get; }
        public Post Post { get; }

        public Accauntant(string name, Post post)
        {
            Name = name;
            Post = post;
        }

        public bool AskForBonus(Post worker, int hours) => 
            premium = (int)worker < hours; // сказано чітко більше

        public override string ToString() =>
           $"Name: {Name}, Post : {Post}, premium: {premium}";
    }

    enum Post
    {
        Dev = 40,
        Frontend_Dev,
        Backend_Dev,
        FullStack_Dev,
        Software_engineer = 45,
        HR = 30,
        PR = 20,
        Database_Administrator,
        Data_Analyst,
        IT_Analyst,
        Director =50,
        CEO=10,
        Else_Position = 60
    }
    #endregion
}