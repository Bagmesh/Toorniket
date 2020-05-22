using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Net;

namespace Турникет
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string cardid = "C:\\Проект Турникет\\БД пользователей.txt";
        private WebClient wc = new WebClient();

        private void button1_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\Проект Турникет\\");
            wc.DownloadFile("https://github.com/Bagmesh/Toorniket/raw/master/Id_polzovatelya.txt", cardid);
        }
        public static string FindID(string s)
        {
            string str = (string)null;
            string[] array = System.IO.File.ReadAllLines(cardid);
            int index1 = Array.IndexOf<string>(array, s);
            for (int index2 = 0; index2 < array.Length; ++index2)
                str = array[index1];
            return str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty)
            {
                int num1 = (int)MessageBox.Show("Введите id карты!");
            }
            if (textBox1.Text == FindID(textBox1.Text))
            {
                string[] array = File.ReadAllLines(cardid);
                int num2 = Array.IndexOf<string>(array, textBox1.Text);
                array[num2 + 1] = (Convert.ToInt32(array[num2 + 1]) - 1).ToString();
                File.Delete(cardid);
                for (int index = 0; index < array.Length; ++index)
                {
                    using (StreamWriter streamWriter = new StreamWriter(cardid, true))
                        streamWriter.WriteLine(array[index]);
                }
                MessageBox.Show("Успешно =D");
            }
            else
            {
                MessageBox.Show("Введенный id не существуюет!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
