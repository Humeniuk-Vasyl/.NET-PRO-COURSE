using System.Reflection;
namespace Ex3
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        Assembly assembly = null;
        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            if (myOpen.ShowDialog(this) == DialogResult.OK)
            {
                try
                {

                    var path = myOpen.FileName;
                    assembly = Assembly.LoadFrom(path);

                    showBox.Text = ""; // якщо ми плануємо декілька разів клацати на open
                    showBox.Text += "Solution " + path + "  - loaded!" + Environment.NewLine + Environment.NewLine;
                }
                catch (FileNotFoundException ex)
                {
                    showBox.Text = ex.Message;
                }
            }

            ShowTypes();        // & methods
            //ShowFields();       // fieds info
            //ShowProps();        // proerties info
            ShowCtors();        // constructors info
            ShowInterfaces();   // intefaces
        }

        private void ShowTypes()
        {
            showBox.Text += "All types in solution " + assembly.FullName + Environment.NewLine;

            foreach (Type type in assembly.GetTypes())
            {
                showBox.Text += "Type:  " + type.Name + Environment.NewLine;
                MethodInfo[] methods = type.GetMethods();
                if (methods != null)
                {
                    foreach (MethodInfo method in methods)
                    {
                        string methStr = "Method:           " + method.Name + "\n";
                        var methodBody = method.GetMethodBody();
                        if (methodBody != null)
                            foreach (var b in methodBody.GetILAsByteArray())
                                methStr += b + ":";
                        showBox.Text += methStr + Environment.NewLine;
                    }
                }
            }
        }

        private void ShowFields()
        {
            showBox.Text += Environment.NewLine + "All fields" + Environment.NewLine;

            foreach (Type type in assembly.GetTypes())
            {
                showBox.Text += "Type:  " + type.Name + Environment.NewLine;
                FieldInfo[] fields = type.GetFields();
                if (fields != null)
                    foreach (var field in fields)
                        showBox.Text += "Field:         " + field.Name + Environment.NewLine;
            }
        }

        private void ShowProps()
        {
            showBox.Text += Environment.NewLine + "All props" + Environment.NewLine;

            foreach (Type type in assembly.GetTypes())
            {
                showBox.Text += "Type:  " + type.Name + Environment.NewLine;
                PropertyInfo[] props = type.GetProperties();
                if (props != null)
                    foreach (var prop in props)
                        showBox.Text += "Prop:          " + prop.Name + Environment.NewLine;
            }
        }

        private void ShowCtors()
        {
            showBox.Text += Environment.NewLine + "All contsructors" + Environment.NewLine;
            var types = assembly.GetTypes();
            foreach (Type type in types)
            {
                ConstructorInfo[] ctors = type.GetConstructors();
                if (ctors != null)
                    foreach (var ctor in ctors)
                    {
                        showBox.Text += "Ctor:          " + ctor.Name + Environment.NewLine + "parameters:      ";

                        var partrInfo = ctor.GetParameters();
                        foreach (var parameter in partrInfo)
                            showBox.Text +=parameter.Name + "       ";
                        showBox.Text += Environment.NewLine;
                    }
            }
        }

        private void ShowInterfaces()
        {
            showBox.Text += Environment.NewLine + "All intefaces" + Environment.NewLine;
            foreach (Type type in assembly.GetTypes())
                foreach (var i in type?.GetInterfaces())
                    showBox.Text += "Interface:          " + i + Environment.NewLine;
        }
        private void CloseMenuItem_Click(object sender, EventArgs e) => Close();
    }
}