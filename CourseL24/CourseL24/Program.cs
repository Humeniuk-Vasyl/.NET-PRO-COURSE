using static System.Console;
namespace CourseL24
{
    public class Program
    {
        public static void Main()
        {
            //Ex1:
            //new Ex1().Ex1_L24();

            //Ex2:
            Ex2.Ex2_L24();
        }

        public class Ex2
        {
            static Random rnd = new();
            static int counter = 0;
            char temp;

            public static void Ex2_L24()
            {
                double speedControl = 100; // по невідомій для мене причині кожен наступний запуск
                                           // нового thread прискорює вивід приблизно вдвічі, отже я вирішив зберігати значення,
                                           // та перед початком нового потоку сповільнювати "speedRegular" домножуюючи на 2

                while (true)
                {
                    Thread thread = new(() => new Ex2().LineMaker(rnd.Next(0, WindowWidth), (int)speedControl));
                    thread.Start();
                    Thread.Sleep(rnd.Next(1000, 5000));
                    speedControl *= 2; // можете попробувати що буде без цього теж)
                    //воно навіть більше похоже на те що б мало б бути)
                }
            }

            public int LineMaker(int widthSetup, int speedControl)
            {
                if (counter < 20)
                {
                    temp = (char)rnd.Next(33, 125);
                    ForegroundColor = ConsoleColor.DarkGreen;
                    int i = 0;
                    lock (this)
                    {
                        for (; i < 9; i++)
                        {
                            temp = (char)rnd.Next(33, 125);
                            switch (i)
                            {
                                case < 7:
                                    {
                                        lock (this)
                                        {
                                            SetCursorPosition(widthSetup, i + counter); // TODO change width and add threads
                                            WriteLine(temp);
                                        }

                                    }; break;
                                case 7:
                                    {
                                        lock (this)
                                        {
                                            SetCursorPosition(widthSetup, i + counter);
                                            ForegroundColor = ConsoleColor.Green;
                                            WriteLine(temp);
                                        }
                                    };
                                    break;
                                case 8:
                                    {
                                        lock (this)
                                        {
                                            SetCursorPosition(widthSetup, i + counter);
                                            ForegroundColor = ConsoleColor.White;
                                            WriteLine(temp);
                                        }

                                    }; break;
                                default:
                                    break;
                            }
                        }
                        Thread.Sleep(speedControl);
                        Clear();
                    }
                    ++counter;
                    LineMaker(widthSetup, speedControl);
                    return speedControl;
                }
                else
                {
                    counter = 0;
                    LineMaker(widthSetup, speedControl);
                    return speedControl;
                }
            }
        }
    }
    public class Ex1
    {
        static int c = 0;
        public void Ex1_L24()
        {
            while (c <= 50) //насправді 100 викликів тобто насправді c<100
            {
                Thread thread = new(Ex1_L24);
                lock (this)
                {
                    Thread.Sleep(10);
                    WriteLine($"Test{c}");
                } // по суті лиш вивід (і затримку) слід лочити
                  // і важливо поміщати в нього this а не instance thread

                c++;
                thread.Start();
            }
        }
    }
}