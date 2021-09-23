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

        private void button1_Click(object sender, EventArgs e)
        {
            calc.checkInput("");
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
