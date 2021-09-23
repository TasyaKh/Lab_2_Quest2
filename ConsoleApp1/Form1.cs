using System;
using System.Windows.Forms;

namespace ConsoleApp1
{
    public partial class Form1 : Form
    {
        Calculaitons calc;
        string forTextBoxes;
        public Form1()
        {
            InitializeComponent();
            calc = new Calculaitons();

            forTextBoxes = "Введите значение";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;

            int months;

            TextBox textBoxNum  = textBox1; //Нужен, чтобы узнать в каком боксе возникло исключение

            try
            {

                if (calc.checkInput(textBox1.Text)) //Если корректно вверен вклад
                {
                    textBoxNum = textBox2;

                    if (calc.checkInput(textBox2.Text)) //Если корректно введено превышение увеличения по вкладу
                    {
                        months = calc.monthsForA(Convert.ToInt32(textBox1.Text), 
                            Convert.ToInt32(textBox2.Text));

                        label2.Text = $"Ответ: за {months} месяцев(а) величина ежемесячного увеличения вклада превысит " 
                            + textBox2.Text +" руб.";
                        label2.Visible = true;
                    }

                    textBoxNum = textBox3;

                    if (calc.checkInput(textBox3.Text)) //Если корректно введено превышение по вкладу
                    {
                        months = calc.monthsForB(Convert.ToInt32(textBox1.Text),
                            Convert.ToInt32(textBox3.Text));

                        label3.Text = $"Ответ: за {months} месяцев(а) величина ежемесячного увеличения вклада превысит "
                            + textBox3.Text + " руб.";
                        label3.Visible = true;
                    }
                }
            }catch(System.FormatException)
            {
                textBoxNum.ForeColor = System.Drawing.Color.Red; //Меняем цвет шрифта текст бокса, где возникло исключение неправильного ввода

                label4.Visible = true;
                label4.Text = "Введено некорректное значение";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = System.Drawing.Color.Black; //Делаем шрифт всех боксов по умолчанию черным
            
            if (textBox1.Text == forTextBoxes) textBox1.Text = ""; //Меняем значение textBox, если поользователь ничего не вводил
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("")) textBox1.Text = forTextBoxes; //Если поле ввода пусто, то просим пользователя ввести значение
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.ForeColor = System.Drawing.Color.Black;

            if (textBox2.Text == forTextBoxes) textBox2.Text = "";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("")) textBox2.Text = forTextBoxes;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.ForeColor = System.Drawing.Color.Black;

            if (textBox3.Text == forTextBoxes) textBox3.Text = "";
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals("")) textBox3.Text = forTextBoxes;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
