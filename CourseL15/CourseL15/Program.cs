using System.Collections;
using static System.Console;

namespace CourseL15
{
    public class Program
    {
        static Random rnd = new();
        public static void Main()
        {
            /*//Ex1
            MyList<int> myList = new();
            for (int i = 0; i < 20; i++)
                myList.Add(i);
            myList.MyPrint();

            WriteLine($"\n{myList.Contains(4)}");

            myList.Clear();
            myList.MyPrint(); // нічого
            */

            /*//Ex2
            MyList<int> myList2 = new();
            for (int i = 0; i < 20; i++)
                myList2.Add(rnd.Next(10, 100));
            myList2.MyPrint();
            var newList = myList2.GetArray();
            newList.MyPrint();
            */

            //Ex3
            TasksForEx3();
        }

        #region L15_Ex3
        private static void TasksForEx3()
        {
            SortedList<int, string> keyValuePairs = new()
            {
                { 2,"b" }, { 4,"c" }, { 3,"c" }, { 5,"a" }, { 1,"a" }, { 6,"me" }
            };
            // як би я зараз не переплутав ключі, цей тип одразу їх посортує по порядку зростання +
            // так як і в didctionary -> ключі мають бути унікальні

            foreach (var item in keyValuePairs)
                WriteLine($"{item.Key} -> {item.Value}");

            var length = keyValuePairs.Count;
            for (int i = length - 1; i >= 0; i--)
                WriteLine($"{keyValuePairs.Keys[i]} -> {keyValuePairs.Values[i]}");

            //or
            /*foreach (var item in keyValuePairs.Reverse())
                WriteLine($"{item.Key} -> {item.Value}");*/
        }
        #endregion
    }

    #region L15_Ex1
    public interface IMyList<T>
    {
        void Add(T a);

        T this[int index] { get; }

        int Count { get; }

        void Clear();

        bool Contains(T item);
    }

    public class MyList<T> : IMyList<T>, IEnumerable<T>, IEnumerator<T>
    {
        private T[] array;
        private int counter = -1;

        public MyList() => array = Array.Empty<T>();

        public MyList(T[] Array) => array = Array;

        public T this[int index] => array[index];

        public int Count => array.Length;

        public object Current => array[counter];

        T IEnumerator<T>.Current => array[counter];

        public void Add(T a)
        {
            if (array == null)
                array = new T[1] { a };
            else
            {
                var newArray = new T[array.Length + 1];
                var length = array.Length;
                for (int i = 0; i < length; i++)
                {
                    newArray[i] = array[i];
                }
                newArray[length] = a;
                array = newArray;
            }
        }

        public void Clear() => array = Array.Empty<T>();

        public bool Contains(T item) => array.Contains(item); // з вашого дозволу скористаюсь LINQ,
                                                              // який в свою чергу використовує різні equals

        public bool MoveNext()
        {
            if (counter < array.Length - 1)
            {
                counter++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset() => counter = -1;

        public IEnumerator GetEnumerator() => this;

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => ((IEnumerable<T>)array).GetEnumerator();

        public void Dispose()
        {
            //empty for example
        }
    }
    #endregion

    #region L15_Ex2
    static class ExtensionForMyList // прийшлось створити non-generic static class
    {
        //по суті ми перетворюємо колекцію в звичайний масив того типу, яким ми закривали колекцію
        public static T[] GetArray<T>(this MyList<T> list)
        {
            T[] array = new T[list.Count];
            var length = list.Count;
            for (int i = 0; i < length; i++)
                array[i] = list[i];
            return array;
        }

        public static void MyPrint(this IEnumerable objects) // щоб кожен раз foreach не писати
        {
            foreach (var item in objects)
                Write($"{item} ");
            WriteLine();
        }
    }
    #endregion
}