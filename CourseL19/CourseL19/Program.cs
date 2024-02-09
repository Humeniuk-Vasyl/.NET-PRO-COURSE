using System.Reflection;

namespace CourseL19
{
    public class Program
    {
        public static void Main()
        {
            //Ex1:
            // не впевнений що правильно інтерпритував Car_Library до Converter
            // але подальша суть завдання в розгляді рефрексії тож норм)
            /*typeof(Convertor).GetMethod("ConvertorInfo",
                BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(new FarhenheitToCelsiusClass(20), null);*/
            // Current value: 20°F
        }
    }


}