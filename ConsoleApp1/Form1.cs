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

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;

            int months;                                      //Количество месяцев

            int contrib = 0;  //Хранит вклад
            int B;        //Хранит вклад задания В
            int C;        //Хранит вклад задания С
            string message;

            if ((message = calc.inputIsValid(textBox1.Text)).Equals("")) //Проверяем значение на корректность
            {                         //если там есть сообщение, значит есть ошибка и конвертировать не будем
                contrib = Convert.ToInt32(textBox1.Text);                
                Properties.Settings.Default.Contribution = contrib;//Сохраняем значение для следующего запуска   
            }
            else                                                   //В случае ошибки выводим сообщение
            {
                textBox1.ForeColor = System.Drawing.Color.Red;     //Меняем цвет текста бокса на красный
                MessageBox.Show(message);
            }


            if ((message = calc.inputIsValid(textBox2.Text)).Equals(""))
            {
                B = Convert.ToInt32(textBox2.Text);
                Properties.Settings.Default.B = B;

                months = calc.monthsForB(contrib, B); //Находим количество месяцев

                if (contrib > 0)label2.Text = $"Ответ: за {months} месяцев(а) величина ежемесячного увеличения вклада превысит "
                    + textBox2.Text + " руб.";
                label2.Visible = true;
            }
            else
            {
                textBox2.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show(message);
            }


            if ((message = calc.inputIsValid(textBox3.Text)).Equals(""))
            {
                C = Convert.ToInt32(textBox3.Text);
                Properties.Settings.Default.C = C;

                months = calc.monthsForC(contrib, C);

                if(contrib > 0)label3.Text = $"Ответ: за {months} месяцев(а) величина ежемесячного вклада превысит "
                    + textBox3.Text + " руб.";
                label3.Visible = true;
            }
            else
            {
                textBox3.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show(message);
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
