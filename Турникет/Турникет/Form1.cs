using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net;
using System.Windows.Forms;


namespace Турникет
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 5000;
            timer2.Interval = 5000;
            timer3.Interval = 5000;
            timer4.Interval = 2000;
            timer5.Interval = 2000;
            Directory.CreateDirectory("C:\\Проект Турникет\\");
        }
        SoundPlayer spg = new SoundPlayer("C:\\Users\\mesh\\source\\repos\\Турникет\\Турникет\\spg.wav");
        SoundPlayer spb = new SoundPlayer("C:\\Users\\mesh\\source\\repos\\Турникет\\Турникет\\spb.wav");
        bool butt = false;
        bool but2 = false;
        bool but4 = false;
        bool but5 = false;
        bool but6 = false;
        static string cardid = "C:\\Проект Турникет\\БД пользователей.txt";
        WebClient wc = new WebClient();
        int i = 1;
        bool lb1 = false;
        bool lb2 = false;
        private void CloseAway()
        {
            lb2 = true;
            timer5.Start();
            if (!but2)
                label2.BackColor = Color.Red;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            butt = true;
            wc.DownloadFile("https://github.com/Bagmesh/Toorniket/raw/master/Id_polzovatelya.txt", cardid);
            MessageBox.Show("Скачивание успешно завершено");
        }
        public string FindID(string s)
        {
            string str = null;
            string[] array = File.ReadAllLines(cardid);
            int index = Array.IndexOf<string>(array, s);
            if (butt)
            {
                for (int i = 0; i < array.Length; ++i)
                    if (index < array.Length)
                        str = array[index];
            }
            else
                MessageBox.Show("Проверьте бд");
            return str;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty)
            {
                CloseAway();
                spb.Play();
                MessageBox.Show("Введите id карты!");
            }
            string[] array = File.ReadAllLines(cardid);
            int num2 = Array.IndexOf<string>(array, textBox1.Text);
            int t = Convert.ToInt32(array[num2 + 1]);
            if (t != 0)
            {
                if (textBox1.Text != FindID(textBox1.Text))
                {
                    CloseAway();
                    spb.Play();
                    MessageBox.Show("Введенный id не существуюет!");
                }
                else
                {
                    array[num2 + 1] = (t - 1).ToString();
                    File.Delete(cardid);
                    for (int i = 0; i < array.Length; ++i)
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cardid, true))
                            streamWriter.WriteLine(array[i]);
                    }
                    spg.Play();
                    MessageBox.Show("Успешно =D");
                    lb1 = true;
                    timer4.Start();
                    if (but2)
                        label1.BackColor = Color.Green;
                    but2 = true;
                }
            }
            else
            {
                CloseAway();
                spb.Play();
                MessageBox.Show("Пополните карту!");
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\Проект Турникет\\");
            ++i;
            bool T = Convert.ToBoolean(radioButton1.Checked);
            bool G = Convert.ToBoolean(radioButton2.Checked);
            if (T == true)
            {
                if (button1.Visible)
                {
                    if (i < 10)
                        i = 11;
                    using (StreamWriter streamWriter = new StreamWriter(cardid, true))
                    {
                        streamWriter.WriteLine(i);
                        streamWriter.WriteLine(50);
                    }
                }
                else
                {
                    using (StreamWriter streamWriter = new StreamWriter(cardid, true))
                    {
                        streamWriter.WriteLine(i);
                        streamWriter.WriteLine(50);
                    }
                }
            }
            if (G == true)
            {
                if (button1.Visible)
                {
                    if (i < 10)
                        i = 11;
                    using (StreamWriter streamWriter = new StreamWriter(cardid, true))
                    {
                        streamWriter.WriteLine(i);
                        streamWriter.WriteLine(75);
                    }
                }
                else
                {
                    using (StreamWriter streamWriter = new StreamWriter(cardid, true))
                    {
                        streamWriter.WriteLine(i);
                        streamWriter.WriteLine(75);
                    }
                }
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
        }
        private void button4_Click(object sender, EventArgs e)
        {
            but4 = true;
            timer1.Start();
            if (but2)
                button4.BackColor = Color.Green;
            else
            {
                button4.BackColor = Color.Red;
                spb.Play();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            but5 = true;
            timer2.Start();
            if (but2)
                button5.BackColor = Color.Green;
            else
            {
                button5.BackColor = Color.Red;
                spb.Play();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            but6 = true;
            timer3.Start();
            if (but2)
                button6.BackColor = Color.Green;
            else
            {
                button6.BackColor = Color.Red;
                spb.Play();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (but4)
                button4.BackColor = Color.Silver;
            but4 = !but4;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (but5)
                button5.BackColor = Color.Silver;
            but5 = !but5;
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (but6)
                button6.BackColor = Color.Silver;
            but6 = !but6;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            else
                return base.ProcessDialogKey(keyData);

        }
        private void label1_Click(object sender, EventArgs e)
        {       
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (but2)
                label1.BackColor = Color.Gray;
            lb1 = !lb1;
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            if (but2)
                label2.BackColor = Color.Gray;
            lb2 = !lb2;
        }
    }
}