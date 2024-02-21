using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Ex4
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            XmlTextWriter xmlFile = new XmlTextWriter("Ex4Config.xml", Encoding.UTF8)
            {
                Formatting = Formatting.Indented,
                Indentation = 4
            };
            xmlFile.WriteStartDocument();
            xmlFile.WriteStartElement("File_Configs");
            xmlFile.WriteStartElement("MainText");
            xmlFile.WriteStartAttribute("BgColor");
            xmlFile.WriteString(MainText.BackColor.ToKnownColor().ToString());
            xmlFile.WriteEndAttribute();

            xmlFile.WriteStartAttribute("ForeColor");
            xmlFile.WriteString(MainText.ForeColor.ToKnownColor().ToString());
            xmlFile.WriteEndAttribute();

            xmlFile.WriteStartAttribute("FontSize");
            xmlFile.WriteString(MainText.Font.Size.ToString());
            xmlFile.WriteEndAttribute();

            xmlFile.WriteStartAttribute("FontStyle");
            xmlFile.WriteString(MainText.Font.Style.ToString());
            xmlFile.WriteEndAttribute();

            xmlFile.WriteStartAttribute("Content");
            xmlFile.WriteString(MainText.Text);
            xmlFile.WriteEndAttribute();
            xmlFile.WriteEndElement();
            xmlFile.WriteEndElement();
            xmlFile.Close();
        }

        private void redBgBtn_Click(object sender, EventArgs e) => MainText.BackColor = Color.IndianRed;

        private void blueBgBtn_Click(object sender, EventArgs e) => MainText.BackColor = SystemColors.ActiveCaption;

        private void whiteBgBtn_Click(object sender, EventArgs e) => MainText.BackColor = Color.White;

        private void blackTextColorBtn_Click(object sender, EventArgs e) => MainText.ForeColor = Color.Black;

        private void greenTextColorBtn_Click(object sender, EventArgs e) => MainText.ForeColor = Color.Green;

        private void FontSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(FontSizeTextBox.Text, out int res) && res != 0)
                MainText.Font = new Font("Berlin Sans FB", res, GraphicsUnit.Point);
            else
                MainText.Text += "Font wasn't parsed";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Ex4Config.xml");

            XmlNode MainTextConfig = xmlDoc?.SelectSingleNode("File_Configs/MainText");
            MainText.Text = MainTextConfig.Attributes["Content"].Value;
            MainText.ForeColor = Color.FromName(MainTextConfig.Attributes["ForeColor"].Value);
            MainText.BackColor = Color.FromName(MainTextConfig.Attributes["BgColor"].Value);
            var size = MainTextConfig.Attributes["FontSize"].Value;
            var fontStyle = MainTextConfig.Attributes["FontStyle"].Value;
            FontStyle fS = (FontStyle)Enum.Parse(typeof(FontStyle), fontStyle, true);
            FontSizeTextBox.Text = size; // важливо не поставити пізніше ніж зміна шрифту
                                         // інакше, запуститься FontSizeTextBox_TextChanged

            MainText.Font = new Font("Berlin Sans FB",
                float.Parse(size),
                fS,
                GraphicsUnit.Point);
        }

        private void regularFont_Click(object sender, EventArgs e)
            => MainText.Font = new Font("Berlin Sans FB", float.Parse(FontSizeTextBox.Text), FontStyle.Regular, GraphicsUnit.Point);

        private void boldFont_Click(object sender, EventArgs e)
                        => MainText.Font = new Font("Berlin Sans FB", float.Parse(FontSizeTextBox.Text), FontStyle.Bold, GraphicsUnit.Point);
        
        private void italicFont_Click(object sender, EventArgs e)
            => MainText.Font = new Font("Berlin Sans FB", float.Parse(FontSizeTextBox.Text), FontStyle.Italic, GraphicsUnit.Point);
    }
}
