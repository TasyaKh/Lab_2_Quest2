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

            textBox1.Text = Properties.Settings.Default.Contribution.ToString();
            textBox2.Text = Properties.Settings.Default.B.ToString();
            textBox3.Text = Properties.Settings.Default.C.ToString();
            calc = new Calculaitons();

        }

        private void incorrectInput(TextBox textBoxNum)
        {
            textBoxNum.ForeColor = System.Drawing.Color.Red; //Меняем цвет шрифта текст бокса, где возникло исключение неправильного ввода

            label4.Visible = true;
            label4.Text = "Введено некорректное значение";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;

            int months;
            int contrib = 0;
            int B;
            int C;

            try
            {
                if ((contrib = calc.convertInput(textBox1.Text)) > 0) //Если корректно вверен вклад
                {
                    Properties.Settings.Default.Contribution = contrib;
                }
            }
            catch (System.FormatException)
            {
                Properties.Settings.Default.Contribution = 0;
                incorrectInput(textBox1);
            }


            try
            {
                if (contrib > 0 && (B = calc.convertInput(textBox2.Text)) >= 0) //Если корректно введено превышение увеличения по вкладу
                {
                    Properties.Settings.Default.B = B;

                    months = calc.monthsForA(contrib, B);
                    label2.Text = $"Ответ: за {months} месяцев(а) величина ежемесячного увеличения вклада превысит "
                        + textBox2.Text + " руб.";
                    label2.Visible = true;
                }
            }
            catch (System.FormatException)
            {
                Properties.Settings.Default.B = 0;
                incorrectInput(textBox2);
            }


            try
            {
                if (contrib > 0 && (C = calc.convertInput(textBox3.Text)) >= 0) //Если корректно введено превышение по вкладу
                {
                    Properties.Settings.Default.C = C;

                    months = calc.monthsForB(contrib, C);
                    label3.Text = $"Ответ: за {months} месяцев(а) величина ежемесячного увеличения вклада превысит "
                        + textBox3.Text + " руб.";
                    label3.Visible = true;
                }
            }
            catch (System.FormatException)
            {
                Properties.Settings.Default.C = 0;
                incorrectInput(textBox3);
            }

            Properties.Settings.Default.Save();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = System.Drawing.Color.Black; //Делаем шрифт всех боксов по умолчанию черным
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.ForeColor = System.Drawing.Color.Black;

         }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.ForeColor = System.Drawing.Color.Black;
        }
    }
}
