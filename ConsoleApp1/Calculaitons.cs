using System;

namespace ConsoleApp1
{
    public class Calculaitons
    {

        public bool checkInput(string txt)
        {
            int num = Convert.ToInt32(txt);

            if(num>0)return true;
            return false;
        }
    }
}
