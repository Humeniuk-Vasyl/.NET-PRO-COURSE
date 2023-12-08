using static System.Console;
using static System.Math;

namespace CourseL8
{
    class Program
    {
        static void Main()
        {
            /* //Ex1
            #region Ex1
            Tail someTail = new() { Length = 45, Kind = "multi-haired" };
            //TailedAnimal someTailedAnimal = new()
            //{
            //    AnimalTail = someTail,
            //    AnimalColor = "multi-color",
            //    Age = 5
            //};
            Dog mySuperDog = new()
            {
                Nickname = "Beethoven",
                AnimalTail = someTail,
                AnimalColor = "multi-color",
                Age = 5
            };
            mySuperDog.ShowInfo();
            #endregion*/

            /*//Ex2
            #region Ex2
            Box box = new() { DrawerVolume = 70 };
            Pyramid pyram = new(2.5, 2);
            Cylinder cylinder = new(2.1, 2);
            Ball ball = new(2);
            Ball ball2 = new(10);

            box.Add(pyram); //Ok...
            box.Add(cylinder); //Ok..
            box.Add(ball); // Ok...
            box.Add(ball2); //Not enough space...
            box.Add(pyram); //Ok...
            box.Add(cylinder); //Not enough space...
            #endregion*/

            /*//Ex3
            #region Ex3
            Pupil firstPup = new("Vaska");
            ExcellentPupil excellentPup = new("Mishka");
            GoodPupil goodPup = new("Romka");
            BadPupil badPup = new("Kolka");
            Pupil[] pupils = new Pupil[4] { firstPup, excellentPup, goodPup, badPup };
            ClassRoom myClassRoom = new(pupils);

            myClassRoom.ClassInfo();

            // Я не дуже зрозумів що значить користувач може передати
            // 2 чи 3 аргументи але мабуть це про конструктори ClassRoom
            ClassRoom myClassRoom2 = new(firstPup, goodPup);
            myClassRoom2.ClassInfo();
            ClassRoom myClassRoom3 = new(badPup, excellentPup, goodPup);
            myClassRoom3.ClassInfo();
            #endregion*/

            /*//Ex4
            #region Ex4
            string[] tmpStudyCouses = new[] { "History", "Eng", "Programming" };
            string[] badTmpStudyCouses = new[] { "History", "Eng", "Programming", "Else" };

            Student Vasyl = new(2001, "Vasyl", "Terny");
            Vasyl.SetStudyCourse(tmpStudyCouses);
            Student Dmytro = new(2002, "Dmytro", "Vaskiv", tmpStudyCouses);
            Student Anton = new(2003, "Anton", "Vaskiv", badTmpStudyCouses); // Error: Only [1;3]
            Anton.SetStudyCourse(tmpStudyCouses);
            Student Mykola = new(2000, "Mykola", "Kuzma", tmpStudyCouses);
            Student Misha = new(2002, "Misha", "Zorin", tmpStudyCouses);

            // Я розумію що в клас можна добавляти одних і тих самих студентів,
            // але робити перевірки на це нудно + в тз нічого за це не сказано)
            Student[] studArray = new Student[] { Vasyl, Dmytro, Anton, Mykola, Misha };
            Student[] badStudArray = new Student[] { Vasyl, Dmytro };
            Teacher Sergiy = new(1975, "Sergiy", "Sirko", new Student[] { Vasyl, Dmytro }); //Error: Only[3; 15]            
            Sergiy.SetStudents(studArray);
            Teacher Himars = new(1996, "M142", "HIMARS");
            Himars.SetStudents(badStudArray); //Error: Only[3; 15]
            Himars.SetStudents(new Student[] { Misha, Vasyl, Anton });

            PeopleInfo peopleInfo = new(new Person[] { Sergiy, Sergiy.Students[0], Sergiy.Students[1],
                Himars, Himars.Students[0], Anton });

            peopleInfo.GetPeopleInfo();
            #endregion*/

            /*//Ex5
            #region Ex5
            Car ferrari1 = new("P80/C", "Red", 200000);
            Car ferrari2 = new();
            ferrari2.Input("150° Italia", "Black", 320000);
            Car ferrari3 = new()
            {
                Name = "LaFerrari",
                Color = "Green",
                Price = 520000
            };
            ferrari1.Print();
            ferrari2.Print();
            ferrari3.Print();

            ferrari1.ChangePrice(10);
            ferrari2.ChangePrice(10);
            ferrari3.ChangePrice(10);

            WriteLine("AFTER SALE:\n");
            ferrari1.Print();
            ferrari2.Print();
            ferrari3.Print();
            #endregion*/
        }

        #region Ex1_L8
        class Tail
        {
            int length;
            string? kind;
            public Tail()
            {
                length = 1;
                kind = "no";
            }
            public Tail(int length, string kind)
            {
                Length = length;
                Kind = kind;
            }
            public int Length { get => length; set => length = value; }
            public string? Kind { get => kind; set => kind = value; }
        }
        class TailedAnimal
        {
            Tail animalTail;
            string? animalColor;
            int age;
            
            public TailedAnimal()
            {
                animalTail = new Tail();
                animalColor = "no";
                age = 0;
            }

            public TailedAnimal(Tail animalTail, string animalColor, int age)
            {
                AnimalTail = animalTail ?? new Tail();
                AnimalColor = animalColor;
                Age = age;
            }

            public Tail AnimalTail { get => animalTail; set => animalTail = value; }
            public string? AnimalColor { get => animalColor; set => animalColor = value; }
            public int Age { get => age; set => age = value; }
        }
        class Dog : TailedAnimal
        {
            string? nickname;

            public Dog()
            {
                nickname = "no";
                AnimalTail = new Tail();
                AnimalColor = "no";
                Age = 0;
            }

            public Dog(string? nickname, Tail animalTail, string animalColor, int age)
            : base(animalTail, animalColor, age) => Nickname = nickname;

            public string? Nickname { get => nickname; set => nickname = value; }

            public void ShowInfo() =>
            WriteLine($"Dog {nickname}\n" +
                $"color:{AnimalColor}\n" +
                $"age: {Age}\n" +
                $"tail length: {AnimalTail.Length}\n" +
                $"& tail kind: {AnimalTail.Kind} ");
        }
        #endregion

        #region Ex2_L8
        class Shape
        {
            double volume;

            public double Volume { get => volume; }

            public double GetVolume() => Volume;

            protected void SetVolume(double someVolume) => volume = someVolume;
        }

        class Pyramid : Shape
        {
            public Pyramid(double height, double baseArea) =>
                SetVolume(Round(1.0 / 3 * (height * baseArea), 4));

            public void SetVolume(double height, double baseArea) =>
                SetVolume(Round(1.0 / 3 * (height * baseArea), 4));
        }

        class Cylinder : Shape
        {
            public Cylinder(double height, double radius) =>
            SetVolume(Round(height * PI * radius * radius, 4));
        }

        class Ball : Shape
        {
            public Ball(double radius) =>
            SetVolume(Round((4 * PI * Pow(radius, 3)) / 3, 4));
            //public void SetVolume(double radius) => SetVolume(Round((4 * PI * Pow(radius, 3)) / 3, 4)); //Цікава помилка
        }

        class Box
        {
            double drawerVolume;
            private bool endOfSpace = false;

            public double DrawerVolume { get => drawerVolume; set => drawerVolume = value; }

            public bool Add(Shape someShape)
            {
                endOfSpace = (DrawerVolume - someShape.GetVolume() <= 0);
                DrawerVolume -= (endOfSpace) ? 0 : someShape.GetVolume();
                SpaceEnd();
                return endOfSpace;
            }

            private void SpaceEnd() =>
                WriteLine(((endOfSpace == true) ? "Not enough space." : "Ok.") +
                $" Drawer volume exist: {Round(DrawerVolume, 3)}");
        }
        #endregion

        #region Ex3_L8
        class ClassRoom
        {
            public Pupil[] pupilClass { get; set; }

            public ClassRoom(Pupil[] pupils) =>
                pupilClass = pupils;

            public ClassRoom(Pupil pup1, Pupil pup2) =>
                pupilClass = new Pupil[2] { pup1, pup2 };

            public ClassRoom(Pupil pup1, Pupil pup2, Pupil pup3) =>
                pupilClass = new Pupil[3] { pup1, pup2, pup3 };

            public void ClassInfo()
            {
                WriteLine($"Your {this} info:");
                foreach (var pup in pupilClass)
                    pup.PupilInfo();
            }
        }
        class Pupil
        {
            string name;

            public Pupil(string Name) =>
                name = Name;

            public string Name { get => name; set => name = value; }

            virtual protected void Study() =>
                WriteLine("Just Study!");

            virtual protected void Read() =>
                WriteLine("Just Read!");

            virtual protected void Write() =>
                WriteLine("Just Write!");

            virtual protected void Relax() =>
                WriteLine("Just Relax!");

            public void PupilInfo()
            {
                WriteLine($"About {name}:");
                Study(); Read(); Write(); Relax();
                WriteLine();
            }
        }
        class ExcellentPupil : Pupil
        {
            public ExcellentPupil(string name) : base(name) { }
            override protected void Study() =>
                WriteLine("Excellent Study!");

            override protected void Read() =>
                WriteLine("Excellent Read!");

            override protected void Write() =>
                WriteLine("Excellent Write!");

            override protected void Relax() =>
                WriteLine("Bad Relax(");
        }
        class GoodPupil : Pupil
        {
            public GoodPupil(string name) : base(name) { }

            override protected void Study() =>
                WriteLine("Good Study!");

            override protected void Read() =>
                WriteLine("Good Read!");

            override protected void Write() =>
                WriteLine("Good Write!");

            override protected void Relax() =>
                WriteLine("Good Relax!");
        }
        class BadPupil : Pupil
        {
            public BadPupil(string name) : base(name) { }
            override protected void Study() =>
                WriteLine("Bad Study!");

            override protected void Read() =>
                WriteLine("Bad Read!");

            override protected void Write() =>
                WriteLine("Bad Write!");

            override protected void Relax() =>
                WriteLine("Maxed out Relax=)");
        }
        #endregion

        #region Ex4_L8
        class Person
        {
            private int birthYear;
            private string name;
            private string surname;
            private string role;

            public int BirthYear { get => birthYear; set => birthYear = value; }
            public string Name { get => name; set => name = value; }
            public string Surname { get => surname; set => surname = value; }
            public string Role { get => role; set => role = value; }

            public Person()
            {
                BirthYear = 0;
                Name = "no name";
                Surname = "no surname";
            }

            public Person(int birthYear, string name, string surname)
            {
                BirthYear = birthYear;
                Name = name;
                Surname = surname;
            }
        }

        class Student : Person
        {
            string[] studyCourses { get; set; }

            public Student(int birthYear, string name, string surname)
                : base(birthYear, name, surname) { Role = "Student"; }

            public Student(int birthYear, string name, string surname, string[] StudyCourses)
                : base(birthYear, name, surname)
            {
                Role = "Student";
                SetStudyCourse(StudyCourses);
            }

            /// <summary>
            /// Study courses prop must contain at least 1 and max 3 courses in itself
            /// </summary>
            public void SetStudyCourse(string[] StudyCourses)
            {
                if (StudyCourses != null && StudyCourses.Length <= 3 && StudyCourses.Length > 0)
                    studyCourses = StudyCourses;
                else
                    WriteLine("Error: Only [1;3]");
            }

            public void DisplayStudyCourses()
            {
                Write("Study Courses: ");
                foreach (var course in studyCourses)
                    Write("{0} ", course);
                WriteLine();
            }
        }

        class Teacher : Person
        {
            Student[] students;

            public Teacher(int birthYear, string name, string surname)
                : base(birthYear, name, surname) => Role = "Teacher"; 

            public Teacher(int birthYear, string name, string surname, Student[] students)
                : base(birthYear, name, surname)
            {
                Role = "Teacher";
                SetStudents(students);
            }

            public Student[] Students { get => students; }

            /// <summary>
            /// when assigning students to a teacher: [3-15] of them
            /// </summary>
            public void SetStudents(Student[] Students)
            {
                if (Students != null && Students.Length <= 15 && Students.Length >= 3)
                    students = Students;
                else
                    WriteLine("Error: Only [3;15]");
            }

            public void ShowTeacherStudents()
            {
                Write("Students: ");
                foreach (var student in Students)
                    Write("{0} ", student.Name);
                WriteLine();
            }
        }

        class PeopleInfo
        {
            Person[] peopleArray;

            public PeopleInfo(Person[] PeopleArray)
            {
                peopleArray = PeopleArray;
            }

            public Person[] PeopleArray { get => peopleArray; set => peopleArray = value; }

            /// <summary>
            /// This method returns all people inside grouped by ascending of them birthyear
            /// </summary>
            public void GetPeopleInfo()
            {
                Person[] sortedPeopleArray = SortPeopleByBirth(PeopleArray);
                WriteLine("All people grouped by birth ascending:");
                foreach (var people in sortedPeopleArray)
                {
                    WriteLine($"Birth year: {people.BirthYear}\n" +
                    $"Name: {people.Name}\n" +
                    $"Surname: {people.Surname}\n" +
                    $"Role: {people.Role}");
                    if (people.Role == "Student")
                        (people as Student)?.DisplayStudyCourses();
                    if (people.Role == "Teacher")
                        (people as Teacher)?.ShowTeacherStudents();
                    WriteLine();
                }
            }

            private static Person[] SortPeopleByBirth(Person[] peopleArray)
            {
                // очевидно що це легше було би з LINQ (та хоча би з list) але досі обійдемся без нього -_-
                int length = peopleArray.Length;
                for (var i = 1; i < length; i++)
                    for (var j = 0; j < length - i; j++)
                        if (peopleArray[j].BirthYear > peopleArray[j + 1].BirthYear)
                            Swap(ref peopleArray[j], ref peopleArray[j + 1]);
                return peopleArray;
            }

            private static void Swap(ref Person p1, ref Person p2)
            {
                //(p2, p1) = (p1, p2); // саме IDE пропонує)
                var temp = p1;
                p1 = p2;
                p2 = temp;
            }
        }
        #endregion

        #region Ex5_forL7
        class Car
        {
            string? name;
            string? color;
            double price;
            const string CompanyName = "Ferrari";

            public Car()
            {
                name = "No name";
                color = "No color";
                price = 0;
            }

            public Car(string? Name, string? Color, double Price) =>
                Input(Name, Color, Price);

            public Car(string? Name, string? Color)
                : this(Name, Color, 0) { }

            public void Input(string Name, string Color, double Price)
            //: this(Name, Color, Price) // на жаль такого варіанту немає
            //  натомість можна викликати метод з конструктора
            {
                name = Name;
                color = Color;
                price = Price;
            }  // нащо не зрозумів, але так в завданні

            public string? Name { get => name; set => name = value; }
            public string? Color { get => color; set => color = value; }
            public double Price { get => price; set => price = value; }

            public void Print() =>
                WriteLine($"About this {CompanyName}: \n" +
                    $"Name: {name}\n" +
                    $"Color: {color}\n" +
                    $"Current price: {price}\n");

            public void ChangePrice(double percentToChange) =>
                Price -= Price * (percentToChange / 100);
        }
        #endregion
    }
}