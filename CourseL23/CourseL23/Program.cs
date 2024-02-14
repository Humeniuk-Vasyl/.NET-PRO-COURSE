using System.Xml.Serialization;
using static System.Console;


namespace CourseL23
{
    public class Program
    {
        public static void Main()
        {
            //Ex1:
            //Ex1_Test();

            //Ex2:
            //Ex2_Test();

            //Ex3:
            Ex3_Test();
        }

        #region Ex1
        private static void Ex1_Test()
        {
            XmlSerializer serializer = new(typeof(Ex1_L23));

            Ex1_L23 exFrom = new();

            FileStream stream = new("Serialization.xml", FileMode.Create,
                FileAccess.Write, FileShare.Read);

            serializer.Serialize(stream, exFrom);

            stream.Close();
            WriteLine("Ex1 Serialized!");
        }
        #endregion

        #region Ex2
        private static void Ex2_Test()
        {
            Ex2_L23 exFrom = new();

            //part1: dafault way з встроєною серіалізацією

            /*XmlSerializer serializer2 = new(typeof(Ex2_L23));
            FileStream stream = new("Serialization2.xml", FileMode.Create,
                FileAccess.Write, FileShare.Read);

            serializer2.Serialize(stream, exFrom);

            stream.Close();*/


            //part2: варіант з перезаписуванням елементів на атрибути
            // без змін самого класу Ex2_L23

            XmlAttributeOverrides overrides = new();
            XmlAttributes attributes = new()
            {
                XmlAttribute = new XmlAttributeAttribute()
            };

            overrides.Add(typeof(Ex2_L23), "Name", attributes);
            overrides.Add(typeof(Ex2_L23), "Count", attributes);
            // version проігнорив тож воно і не добавилося а залишилось елементом
            // override ToString проігнорилось взагалі (і славно))

            XmlSerializer overriddenSerializer = new(typeof(Ex2_L23), overrides);

            // інший спосіб зробити той же запис
            using TextWriter writer = new StreamWriter("Serialization2.xml");
            overriddenSerializer.Serialize(writer, exFrom);
            writer.Close();

            WriteLine("Ex2 Serialized!");
        }
        #endregion

        #region Ex3
        private static void Ex3_Test()
        {
            XmlSerializer serializer = new(typeof(Ex2_L23));

            Ex2_L23? exTo;
            FileStream stream2 = new("Serialization2.xml", FileMode.Open,
                FileAccess.Read, FileShare.Read);

            exTo = serializer.Deserialize(stream2) as Ex2_L23;
            WriteLine($"EX3:\nEx2_L23 deserialized:\n{exTo}");
        }
        #endregion

    }

    [XmlRoot("Example_1_Lesson_23")]
    public class Ex1_L23
    {
        static readonly Random rnd = new();
        private string? name;
        private int count;

        public Ex1_L23()
        {
            name = "SomeName";
            count = rnd.Next(1000, 200000);
        }

        [XmlAttribute()]
        public string? Name { get => name; set => name = value; }


        [XmlElement("Number")]
        public int Count { get => count; set => count = value; }

        [XmlIgnore]
        public int Version { get; set; } = 43215678;
    }

    [Serializable]
    public class Ex2_L23
    {
        private string? name = "Ex2";
        private int count = 100;

        public string? Name { get => name; set => name = value; }

        public int Count { get => count; set => count = value; }

        public int Version { get; set; } = 43215678;

        public override string ToString() => $"Name: {Name}\n" +
            $"Count: {Count}\nVersion: {Version}";
    }
}