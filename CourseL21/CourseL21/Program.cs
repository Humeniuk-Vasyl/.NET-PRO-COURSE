using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.XPath;
using static System.Console;
using static System.Math;

namespace CourseL21
{
    public class Program
    {
        public static void Main()
        {
            //Ex1:
            //Ex1_L21();

            //Ex2:
            //Ex2_L22();

            //Ex3:
            Ex3_L21();

        }

        private static void Ex1_L21()
        {
            XmlTextWriter xmlFile = new("TelephoneBook.xml", System.Text.Encoding.UTF8)
            {
                Formatting = Formatting.Indented,
                Indentation = 2,
                IndentChar = '\t'
            };
            xmlFile.WriteStartDocument();
            xmlFile.WriteStartElement("MyContacts");
            xmlFile.WriteStartElement("Contact");
            xmlFile.WriteStartAttribute("TelephoneNumber");
            xmlFile.WriteString("0777777777");
            xmlFile.WriteEndAttribute();
            xmlFile.WriteString("Сталевий Edvard");
            xmlFile.WriteEndElement();
            xmlFile.WriteEndElement();
            xmlFile.Close();            //як ви й казали це можна було б зробити по нормальному
                                        //в for, але для такого обсягу - цього достатньо

            WriteLine("XML file created successfully!");
        }

        private static void Ex2_L22()
        {
            //Way 1 (self formatted):
            string urlWay = "TelephoneBook.xml";
            XmlTextReader reader = new(urlWay);
            WriteLine($"Text from {urlWay}");
            while (reader.Read())
                switch (reader.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:
                    case XmlNodeType.Element:
                        Write("<" + reader.Name);
                        while (reader.MoveToNextAttribute())
                            Write(" " + reader.Name + "=\"" + reader.Value + "\"");
                        Write(">\n");
                        break;
                    case XmlNodeType.Text:
                        WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        Write("</" + reader.Name + ">\n");
                        break;
                }   // Цей варіант найшов на MSDN, він досить читабельно витягує текст.
                    // Якщо просто через Read, всерівно довелося б якось через if
                    // обробляти EndElement

            reader.Close();

            WriteLine(new string('\n', 3));
            //Way 2 (formatted but without understanding):
            foreach (string s in File.ReadAllLines(urlWay))
                WriteLine(s);
        }

        private static void Ex3_L21()
        {
            string urlWay = "TelephoneBook.xml";

            #region Ex3_Test1
            /*XmlTextReader reader = new(urlWay);
            while (reader.Read())
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "Contact")
                        {
                            Write("<" + reader.Name);
                            while (reader.MoveToNextAttribute())
                                Write(" " + reader.Name + "=\"" + reader.Value + "\"");
                            Write(">\n");
                        }
                        break;
                }
            */
            #endregion

            #region Ex3_Test2
            /*XPathDocument doc = new(urlWay);
            XPathNavigator nav = doc.CreateNavigator();

            XPathNodeIterator numbers = nav.Select("MyContacts/Contact/@TelephoneNumber");
            XPathNodeIterator names = nav.Select("MyContacts/Contact");
            
            List<string> nums = new();
            List<string> nam = new();
            foreach (var num in numbers)
                nums.Add(num.ToString());
            foreach (var name in names)
                nam.Add(name.ToString());
            //XPathNodeIterator дуже противна негнучка штука)

            List<(string,string)> res = nums.Zip(nam, (item1, item2) => (item1, item2)).ToList();

            foreach (var item in res)
                WriteLine($"Contact => {item.Item1} -> {item.Item2}");*/
            #endregion

            #region Ex3_Test3
            //Way3: Інший спосіб набагато гнучкіший з XmlNodeList:
            XmlDocument xmlDoc = new();
            xmlDoc.Load(urlWay);

            XmlNodeList? contactNodes = xmlDoc?.SelectNodes("MyContacts/Contact");

            foreach (XmlNode contact in contactNodes)
                WriteLine($"Contact => {contact.InnerText} -> {contact.Attributes?["TelephoneNumber"]?.Value}");
            #endregion
        }
    }
}