using CourseL19;
using System.Reflection;

//Ex2:

var CtF = new CelsiusToFarhenheitClass(200);
MethodInfo? CtFTest = typeof(CelsiusToFarhenheitClass).GetMethod("Conversion",
    BindingFlags.NonPublic | BindingFlags.Instance);
CtFTest?.Invoke(CtF, null);
// 200°C to °F=392°F

typeof(FarhenheitToCelsiusClass)?.GetMethod("Conversion",
BindingFlags.NonPublic | BindingFlags.Instance)?
    .Invoke(new FarhenheitToCelsiusClass(-470), null);
// Temperature can't be less than -460°F
 
