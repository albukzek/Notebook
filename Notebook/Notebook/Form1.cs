using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notebook
{
    public partial class Form1 : Form
    {
        Dictionary<string, double> metrica;
        public Form1()
        {
            InitializeComponent();
            metrica = new Dictionary<string, double>();
            metrica.Add("mm", 1);
            metrica.Add("cm", 10);
            metrica.Add("dm", 100);
            metrica.Add("m", 1000);
            metrica.Add("km", 1000000);
        }

        private void InsertDate_Click(object sender, EventArgs e)
        {
           richTextBox1.AppendText(DateTime.Now.ToShortDateString() + "\n") ;
        }

        private void InsertTime_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(DateTime.Now.ToShortTimeString() + "\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string password = "";
            char[] spec_ch = new char[] { '%', '$', '*', '&', '^', '~', ')' };
            if (checkedListBox1.CheckedItems.Count == 0) return;
         
            
            for(int i =0; i<numericUpDown1.Value; i++)
            {
                int n = rnd.Next(0, checkedListBox1.CheckedItems.Count);
                string s = checkedListBox1.CheckedItems[n].ToString();
                switch(s)
                {
                    case "Цифры": password += rnd.Next(10).ToString();
                        break;

                    case "Прописные буквы": password += Convert.ToChar(rnd.Next(65, 88));
                        break;
                    case "Строчные буквы": password += Convert.ToString(rnd.Next(97,122));
                        break;
                    default:
                       password+= spec_ch[rnd.Next(spec_ch.Length)];
                        break;
                }
                
            }
            textBox1.Clear();
            textBox1.AppendText(password.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x1 = metrica[comboBox3.Text];
            double x2 = metrica[comboBox2.Text];
            double x = Convert.ToDouble(textBox2.Text);
            textBox3.Text = (x*(x1/x2)).ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = comboBox2.Text;
            comboBox2.Text = comboBox3.Text;
            comboBox3.Text = s;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.Text)
            {
                case "Длина" :
                    metrica.Clear();
                    metrica.Add("mm", 1);
                    metrica.Add("cm", 10);
                    metrica.Add("dm", 100);
                    metrica.Add("m", 1000);
                    metrica.Add("km", 1000000);
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("mm");
                    comboBox2.Items.Add("cm");
                    comboBox2.Items.Add("dm");
                    comboBox2.Items.Add("m");
                    comboBox2.Items.Add("km");
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("mm");
                    comboBox3.Items.Add("cm");
                    comboBox3.Items.Add("dm");
                    comboBox3.Items.Add("m");
                    comboBox3.Items.Add("km");
                    comboBox2.Text = "mm";
                    comboBox3.Text = "mm";
                    break;
                case "Вес":
                    metrica.Clear();
                    metrica.Add("g", 1);
                    metrica.Add("kg", 1000);
                    metrica.Add("t", 1000000);
                    metrica.Add("lb", 453.6);
                    metrica.Add("oz", 283);
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("g");
                    comboBox2.Items.Add("kg");
                    comboBox2.Items.Add("t");
                    comboBox2.Items.Add("lb");
                    comboBox2.Items.Add("oz");
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("g");
                    comboBox3.Items.Add("kg");
                    comboBox3.Items.Add("t");
                    comboBox3.Items.Add("lb");
                    comboBox3.Items.Add("oz");
                    comboBox2.Text = "g";
                    comboBox3.Text = "g";
                    break;
                default:
                    break;
            }
        }
    }
}
