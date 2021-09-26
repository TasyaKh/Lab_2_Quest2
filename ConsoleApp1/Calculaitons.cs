using System;

namespace ConsoleApp1
{
    public class Calculaitons
    {
        double persent;            //проценты

        public Calculaitons()
        {
            persent = 0.02;       //Проценты по вкладу - 2%
        }

        public string inputIsValid(string boxMessage) //Проверяет введенное значение на корректность
        {
            int num;
            string message = ""; //Сообщение об ошибке

            try
            {
                num = Convert.ToInt32(boxMessage);

                if(num <= 0)//Введенное число не может быть <=0
                {                                                       
                   message = "Значение не может быть равно 0 или быть отрицательным"; //Выводим сообщение об ошибке
                }
            }
            catch (System.FormatException)
            {
                message = "Введенные символы: " + boxMessage; //Пользователь ввел символы
            }

            return message;
        }
        public int monthsForB(double contribution,int B)//Находит набежавшее ежемесячное увеличения вклада
        {
            int months = 0;
            double incContrib = contribution;
            if (contribution > 0 && B > 0) //В случае, если вклад = 0, отрицательный или не символ(во всех этих случаях по умолчанию 0)
            {
                for (int i = 0; incContrib - contribution < B; i++) //Процентры + вклад - первоначальный вклад = Получаем текущий набежавший процент по вкладу
                {
                    incContrib = incContrib + incContrib * persent; //Процентры + вклад
                    months = i + 1;
                }
            }
            return months;
        }

        public int monthsForC(double contribution, int C)//Текущая сумма вклада с набежавшими процентами
        {
            int months = 0;
            double incContrib = contribution;

            if (contribution > 0 && C > 0) //В случае, если вклад = 0, отрицательный или не символ(во всех этих случаях по умолчанию 0)
            {
                for (int i = 0; incContrib < C; i++)
                {
                    incContrib = incContrib + incContrib * persent; //Проценты + вклад
                    months = i + 1;
                }
            }
            return months;
        }
    }
}
