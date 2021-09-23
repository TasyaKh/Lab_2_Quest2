using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Start
    {
        [STAThread]
        static void Main()
        {
            Form1 form = new Form1();
            Application.EnableVisualStyles();
           // Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form);
            
        }
    }
}
