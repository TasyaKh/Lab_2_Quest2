using System;
using System.Windows.Forms;

namespace ConsoleApp1
{
    public partial class Form1 : Form
    {
        Calculaitons calc;
        public Form1()
        {
            InitializeComponent();
            calc = new Calculaitons();
        }

        private void colorFontTextBox(int textBoxNum,bool red)
        {
            var colorFont = System.Drawing.Color.Black;

            if (red) colorFont = System.Drawing.Color.Red;

            switch (textBoxNum)
            {
                case 0:
                    textBox1.ForeColor = colorFont;
                    break;
                case 1:
                    textBox2.ForeColor = colorFont;
                    break;
                case 2:
                    textBox3.ForeColor = colorFont;
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            byte textBoxNum = 0; //Нужен, чтобы узнать в каком боксе возникло исключение
            try
            {
                if (calc.checkInput(textBox1.Text))
                {
                    textBoxNum = 1;
                    if (calc.checkInput(textBox2.Text))
                    {
                        label2.Visible = true;
                        label2.Text = "Ответ: " + ;
                    }
                    textBoxNum = 2;
                    if (calc.checkInput(textBox3.Text))
                    {
                        label3.Visible = true;
                        label3.Text = "Ответ: " +;
                    }
                }
            }catch(System.FormatException)
            {
                colorFontTextBox(textBoxNum, true);

                label4.Visible = true;
                label4.Text = "Введено некорректное значение";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("")) textBox1.Text = "Введите вклад";

        }
    }
}
