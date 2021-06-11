using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace Lesson7_JSON_001
{
    public partial class frmMain : Form
    {
        string jsonText;
        JsonSerializerOptions options;


        public frmMain()
        {
            InitializeComponent();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
             options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IgnoreNullValues = true,
            };
        }

        #region Serialize-Deserialize
        private void btnSerialize_Click(object sender, EventArgs e)
        {

            User curUser = new User();
            curUser.Name = txtName.Text;
            curUser.Age = int.Parse(txtAge.Text);
            curUser.Sex = rbIsMale.Checked ? Sex.maile : Sex.femaile;

            jsonText = encode(JsonSerializer.Serialize(curUser, options));
          
            AppendTextToLog(txtLog, jsonText, Color.Blue);
        }

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(jsonText))
            {
                AppendTextToLog(txtLog,"Сначала должна быть проведена сериализация!", Color.Red);
                return;
            }

            User restoredUser =  JsonSerializer.Deserialize<User>(decode(jsonText), options);
            AppendTextToLog(txtLog, restoredUser.ToString(), Color.Brown);
        }
        #endregion

        #region XSD
        private void btnCreateXSD_Click(object sender, EventArgs e)
        {
            try
            {
                ExportXSD();
            }
            catch (Exception exc)
            {
              AppendTextToLog(txtLog, exc.Message, Color.Red);
            }
        }

        private void ExportXSD()
        {
            XsdDataContractExporter exporter = new XsdDataContractExporter();
            if (exporter.CanExport(typeof(User)))
            {
                exporter.Export(typeof(User));
                XmlSchemaSet mySchemas = exporter.Schemas;

                XmlQualifiedName XmlNameValue = exporter.GetRootElementName(typeof(User));
                string tpNameSpace = XmlNameValue.Namespace;

                foreach (XmlSchema schema in mySchemas.Schemas(tpNameSpace))
                {
                    string fileName = "User.xsd";
                    using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        schema.Write(fs);
                        AppendTextToLog(txtLog, $"Сформирован файл: {fileName}", Color.Green);
                        fileName = fs.Name;
                    }
                    AppendFileToLog(fileName);
               }
           }
        }
        #endregion


        #region кодирование - раскодирование
        private string encode(string s)
        {
            return CleanEncryptSTR(s, "MyPassword", true);
        }

        private string decode(string s)
        {
            return CleanEncryptSTR(s, "MyPassword", false);
        }

        private string CleanEncryptSTR(string mystring, string MyPassword, bool Encrypt)
        {
            // Encrypts strings chars contained in Allowedchars
            // MyString = String to decrypt
            // MyPassword = Password
            // Encrypt True: Encrypy   False: Decrypt
            int i;
            int ASCToAdd;
            string ThisChar;
            int ThisASC;
            int NewASC;
            string MyStringEncrypted = "";
            string AllowedChars;

            AllowedChars = "&0123456789;ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"+
                           "АБВГДЕХЗИЙКЛМНОПРСТУЧЦШЩФЮЯЭЪйцукенгшщзхъфывапролджэячсмитьбю";

            if (MyPassword.Length > 0)
            {
                for (i = 1; i <= mystring.Length; i++)
                {
                    // ThisASC = Asc(Mid(MyString, i, 1))
                    // ThisASC = IntFromArray(Asc(Mid(MyString, i, 1)), MyVector())

                    ThisChar = Strings.Mid(mystring, i, 1);
                    ThisASC = Strings.InStr(AllowedChars, ThisChar);

                    if (ThisASC > 0)
                    {
                        ASCToAdd = Strings.Asc(Strings.Mid(MyPassword, i % MyPassword.Length + 1, 1));
                        if (Encrypt)
                            NewASC = ThisASC + ASCToAdd;
                        else
                            NewASC = ThisASC - ASCToAdd;
                        NewASC = NewASC % AllowedChars.Length;
                        if (NewASC <= 0)
                            NewASC = NewASC + AllowedChars.Length;

                        MyStringEncrypted = MyStringEncrypted + Strings.Mid(AllowedChars, NewASC, 1);
                    }
                    else
                        MyStringEncrypted = MyStringEncrypted + ThisChar;
                }
            }
            else
                MyStringEncrypted = mystring;

            return MyStringEncrypted;
        }
        #endregion


        #region Logging
        private void AppendTextToLog(RichTextBox rtb, string text, Color color,  bool isNewLine = true)
        {
            Font font = new Font("Cambria", 10, FontStyle.Regular);

            rtb.SuspendLayout();
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;

            rtb.SelectionColor = color;
            rtb.SelectionFont = font;
            rtb.AppendText(isNewLine ? $"{text}{ Environment.NewLine}" : text);

            rtb.SelectionColor = rtb.ForeColor;
            rtb.ScrollToCaret();
            rtb.ResumeLayout();
        }

        private void AppendFileToLog(string FullFileName)
        {
            using (StreamReader sr = new StreamReader(FullFileName, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    AppendTextToLog(txtLog, line, Color.Black);
                }
            }

        }
        #endregion
    }
}
