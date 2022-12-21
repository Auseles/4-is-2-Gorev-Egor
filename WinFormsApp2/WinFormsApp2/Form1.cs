using System;
using System.Text;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const string alf = "אבגדהו¸זחטיךכלםמןנסעףפץצקרשתûü‎‏ÿ";
        private void Shifr(bool flag)
        {
            string text = textBox1.Text;
            StringBuilder somestring = new StringBuilder(text);
            string key = textBox3.Text;
            int cntkeyuse = 0;
            int a;
            for (int i = 0; i < somestring.Length; i++)
            {
                string boof = "";
                string boof2 = "";
                if (cntkeyuse >= key.Length)
                {
                    cntkeyuse = 0;
                }
                for (int j = 0; j < alf.Length; j++)
                {
                    if (somestring[i] == alf[j])
                    {
                        int p;
                        boof = key[cntkeyuse].ToString();
                        int myInt = Convert.ToInt32(boof);
                        if (flag)
                        {
                            p = j + myInt;
                        }
                        else
                        {
                            p = j - myInt;
                        }
                        if (p > alf.Length - 1 && flag == true)
                        {
                            p = p - 33;
                        }
                        if (p < 0 && flag == false)
                        {
                            p = p + 33;
                        }
                        boof2 = (alf[p].ToString());
                        cntkeyuse++;
                    }
                }
                textBox2.Text += boof2;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            Shifr(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            Shifr(false);
        }
    }
}