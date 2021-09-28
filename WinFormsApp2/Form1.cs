using System;
using System.Windows.Forms;

namespace Lab_2_For_Lab_2
{
    public partial class Form1 : Form
    {
        Calculaitons calc;
        public Form1()
        {
            InitializeComponent();

            textBox1.Text = Properties.Settings.Default.Contribution.ToString();
            textBox2.Text = Properties.Settings.Default.B_C.ToString();
            comboBox1.SelectedIndex = 0;

            this.label2.MaximumSize = new System.Drawing.Size(this.Size.Width - 50, 50);

            calc = new Calculaitons();

           // toolTip1.SetToolTip(comboBox1, "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "Ответ: ";

            int months;                                      //Количество месяцев

            int contrib = 0;  //Хранит вклад
            string message;

            if ((message = calc.inputIsValid(textBox1.Text)).Equals("")) //Проверяем значение на корректность
            {                         //если там есть сообщение, значит есть ошибка и конвертировать не будем
                contrib = Convert.ToInt32(textBox1.Text);
                Properties.Settings.Default.Contribution = contrib;//Сохраняем значение для следующего запуска   
            }
            else                                                   //В случае ошибки выводим сообщение
            {
                textBox1.ForeColor = System.Drawing.Color.Red;     //Меняем цвет текста бокса на красный
                MessageBox.Show(message + "\n Проверьте поле №1");
            }

            if (contrib > 0)
            {
                int B_C_values;

                if ((message = calc.inputIsValid(textBox2.Text)).Equals(""))
                {
                    B_C_values = Convert.ToInt32(textBox2.Text);

                    if (comboBox1.SelectedIndex == 0)
                    {
                        Properties.Settings.Default.B_C = B_C_values;

                        months = calc.monthsForB(contrib, B_C_values); //Находим количество месяцев
                        label2.Text += $"за {months} месяцев(а) величина ежемесячного увеличения вклада превысит "
                         + textBox2.Text + " руб.";  
                    }
                    else if(comboBox1.SelectedIndex == 1)
                    {
                        Properties.Settings.Default.B_C = B_C_values;

                        months = calc.monthsForC(contrib, B_C_values);
                        label2.Text += $"через {months} месяцев(а) величина вклада превысит "
                              + textBox2.Text + " руб.";
                    }
                }
                else
                {
                    textBox2.ForeColor = System.Drawing.Color.Red;
                    MessageBox.Show(message + "\n Проверьте поле №2");
                }

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //Показать подсказку
        {                                                                          
            string txt = "";
            toolTip1.Hide(comboBox1);    

            if (comboBox1.SelectedIndex == 0)                                  //Если выбрано поле 1
                txt = "a)Превышение увел. вклада";
            else if(comboBox1.SelectedIndex == 1)                              //Если выбрано поле 2
                txt = "б)Превышение вклада";

            toolTip1.SetToolTip(comboBox1, txt);                               //Вывести подсказку
        }

        private void заданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Гражданин 1 марта открыл счет в банке, вложив A руб. " +
                "Через каждый месяц размер вклада увеличивается на 2% от имеющейся суммы. " +
                "Определить: а) за какой месяц величина ежемесячного увеличения вклада превысит B руб.; " +
                "б) через сколько месяцев размер вклада превысит C руб");
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e) //Открыть блокнот со справкой
        {
            string path = "Description.txt";                                    //Файл в дебаге

            if (System.IO.File.Exists(path))
            {
                System.Diagnostics.Process.Start("notepad.exe", path);
            }
        }
    }

}

