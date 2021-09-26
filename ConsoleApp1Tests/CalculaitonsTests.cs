using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class CalculaitonsTests
    {
        Calculaitons calc = new Calculaitons();

        [TestMethod()]
        public void inputIsValidTestWithNegativeMeaning() //Если введем отрицательное значение в текст бокс
        {
            string message = calc.inputIsValid("-1");     //Получить сообщение с ошибкой
            Assert.AreEqual("Значение не может быть равно 0 или быть отрицательным", message);
        }

        [TestMethod()]
        public void inputIsValidTestWithZero()           //Если введем значение 0 в текст бокс
        {
            string message = calc.inputIsValid("0");
            Assert.AreEqual("Значение не может быть равно 0 или быть отрицательным", message);
        }

        [TestMethod()]
        public void inputIsValidTestWithSymbols()           //Если введенное значение явл символом в текст боксе
        {
            string message = calc.inputIsValid("hello");
            Assert.AreEqual("Введенные символы: hello", message);
        }

        [TestMethod()]
        public void monthsForBTestCorrect()
        {
            int months;
            int contribution = 200;
            int B = 10; //Количество превышения увеличения вклада

            months = calc.monthsForB(contribution, B);//Ищем количество месяцев для переменной В
            Assert.AreEqual(3, months); //Сравниваем полученное число месяцев с ожидаемым результатом 

        }

        [TestMethod()]
        public void monthsForCTestCorrect()
        {
            int months;
            int contribution = 200;
            int C = 220; //Количество превышения вклада

            months = calc.monthsForC(contribution, C); //Ищем количество месяцев для переменной С
            Assert.AreEqual(5, months);//Сравниваем полученное число месяцев с ожидаемым результатом 
        }
    }
}