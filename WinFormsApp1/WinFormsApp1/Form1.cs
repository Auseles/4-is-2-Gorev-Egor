using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string[,] alf = new string[5, 5]
        {
            {"W","H","E","A","T"},
            {"S","O","N","B","C"},
            {"D","F","G","I","K"},
            {"L","M","P","Q","R"},
            {"U","V","X","Y","Z"},
        };
        public Form1()
        {
            InitializeComponent();
        }
        private int[] FindNum(string text)
        {
            int[] result = new int[2];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (text == alf[i, j])
                    {
                        result[0] = i;
                        result[1] = j;
                    }
                }
            }
            return result;
        }
        private void Shifr()
        {
            string text = textBox1.Text.ToUpper();
            StringBuilder somestring = new StringBuilder(text);
            for (int i = 0; i < somestring.Length; i += 2)
            {
                if (somestring.Length - i > 1)
                {
                    string lefttext = somestring[i].ToString();
                    string righttext = somestring[i + 1].ToString();
                    int[] cord1 = FindNum(lefttext);
                    int[] cord2 = FindNum(righttext);
                    if (cord1[0] != cord2[0] && cord1[1] != cord2[1])
                    {
                        textBox2.Text += alf[cord1[0], cord2[1]];
                        textBox2.Text += alf[cord2[0], cord1[1]];
                    }
                    else
                    {
                        bool check = true;
                        if (cord1[0] == 4 && cord1[1] == cord2[1])
                        {
                            int save;
                            save = cord1[0];
                            cord1[0] = 0;
                            textBox2.Text += alf[cord1[0], cord2[1]];
                            textBox2.Text += alf[save, cord1[1]];
                            check = false;
                        }
                        if (cord2[0] == 4 && cord1[1] == cord2[1])
                        {
                            cord1[0] = 0;
                            textBox2.Text += alf[cord2[0], cord2[1]];
                            textBox2.Text += alf[cord1[0], cord1[1]];
                            check = false;
                        }
                        if (cord1[1] == 4 && cord1[0] == cord2[0])
                        {
                            cord2[1] = 0;
                            textBox2.Text += alf[cord1[0], cord2[1]];
                            textBox2.Text += alf[cord2[0], cord1[1]];
                            check = false;
                        }
                        if (cord2[1] == 4 && cord1[0] == cord2[0])
                        {
                            int save;
                            save = cord2[1];
                            cord2[1] = 0;
                            textBox2.Text += alf[cord1[0], save];
                            textBox2.Text += alf[cord2[0], cord2[1]];
                            check = false;
                        }
                        if (check)
                        {
                            if (cord1[0] == cord2[0])
                            {
                                textBox2.Text += alf[cord1[0], cord1[1]+1];
                                textBox2.Text += alf[cord2[0], cord2[1]+1];
                            }
                            if (cord1[1] == cord2[1])
                            {
                                textBox2.Text += alf[cord1[0]+1, cord1[1]];
                                textBox2.Text += alf[cord2[0]+1, cord2[1]];
                            }
                        }

                    }
                    
                }
                else
                {
                    textBox2.Text += somestring[somestring.Length - 1].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Shifr();
        }
    }
}