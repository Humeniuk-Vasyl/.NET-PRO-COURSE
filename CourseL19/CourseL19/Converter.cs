using static System.Console;
using static System.Math;
namespace CourseL19
{
    public abstract class Convertor
    {
        protected ConvertorState convertorState;
        protected double currentValue;
        private const double MIN_CELSIUM = -273.15;
        private const double MIN_FARHENHEIT = -460;
        public Convertor(double CurrentValue, ConvertorState ConvertorState)
        {
            currentValue = CurrentValue;
            convertorState = ConvertorState;
        }
        /*static string? _arg;
        static double arg;
        static bool end = false;*/

        public ConvertorState ConvertorState { get => convertorState; }

        public double CurrentValue { get => currentValue; set => currentValue = value; }
        /*
               public static void Conversion()
               {
                   while (end == false)
                   {
                       while (true)
                       {
                           Write("Enter argument to convert: ");
                           _arg = ReadLine();

                           if (double.TryParse(_arg, out arg))
                               break;
                           WriteLine("arg wasn't parsed. Plz enter again");
                       }
                   Start:
                       WriteLine("\nChoose 1 - CelsiusToFahrenheit or 2 - FahrenheitToCelsius or 0 for exit):");
                       string sign = ReadLine();
                       switch (sign)
                       {
                           case "0": end = true; break;
                           case "1": CelsiusToFahrenheit(arg); break;
                           case "2": FahrenheitToCelsius(arg); break;
                           default:
                               WriteLine("Operation unfound. Plz enter else sign from existing:\n" +
                                   "1, 2 or 0 for exit");
                               goto Start;
                       }
                   }
               }
       */

        public static void CelsiusToFahrenheit(double temperatureCelsius) =>
            WriteLine((temperatureCelsius >= MIN_CELSIUM) ?
                $"{temperatureCelsius}°C to °F={Round(temperatureCelsius * 9 / 5 + 32, 3)}°F" :
                $"Temperature can't be less than {MIN_CELSIUM}°C");

        public static void FahrenheitToCelsius(double temperatureFahrenheit) =>
            WriteLine((temperatureFahrenheit >= MIN_FARHENHEIT) ?
            $"{temperatureFahrenheit}°F to ={Round((temperatureFahrenheit - 32) / ((double)9 / 5), 3)}°C" :
            $"Temperature can't be less than {MIN_FARHENHEIT}°F");

        protected abstract void Conversion();
        private void ConvertorInfo() => WriteLine($"Current value: {CurrentValue}" +
               $"{((ConvertorState == ConvertorState.Celsius) ? "°C" : "°F")}");
    }

    public class FarhenheitToCelsiusClass : Convertor
    {
        public FarhenheitToCelsiusClass(double CurrentValue)
            : base(CurrentValue, ConvertorState.Farhenheit) { }

        protected override void Conversion() => FahrenheitToCelsius(CurrentValue);
    }
    public class CelsiusToFarhenheitClass : Convertor
    {
        public CelsiusToFarhenheitClass(double CurrentValue)
            : base(CurrentValue, ConvertorState.Celsius) { }

        protected override void Conversion() => CelsiusToFahrenheit(CurrentValue);
    }

    public enum ConvertorState
    {
        Celsius = 1,
        Farhenheit
    }

}