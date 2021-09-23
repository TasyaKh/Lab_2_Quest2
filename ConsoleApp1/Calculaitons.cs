using System;

namespace ConsoleApp1
{
    public class Calculaitons
    {
        double persent; //проценты

        public Calculaitons()
        {
            persent = 0.02; //Проценты по вкладу 2%

        }
        public int convertInput(string txt) //Проверить ввод пользователя
        {
            int num = Convert.ToInt32(txt);
            if (num < 0) throw new System.FormatException();
            return num;
        }

        public int monthsForA(double contribution,int B)//Находит набежавшее ежемесячное увеличения вклада
        {
            int months = 0;
            double incContrib = contribution;
            for (int i = 0; incContrib - contribution < B; i++) //Процентры + вклад - первоначальный вклад = Получаем текущий набежавший процент по вкладу
            {
                incContrib = incContrib + incContrib * persent; //Процентры + вклад
                months = i + 1;
            }
            return months;
        }

        public int monthsForB(double contribution, int C)//Текущая сумма вклада с набежавшими процентами
        {
            int months = 0;
            double incContrib = contribution;
            for (int i = 0; incContrib < C; i++)
            {
                incContrib = incContrib + incContrib * persent; //Проценты + вклад
                months = i + 1;
            }
            return months;
        }
    }
}
