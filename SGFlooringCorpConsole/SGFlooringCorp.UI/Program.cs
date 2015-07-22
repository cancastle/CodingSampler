using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooringCorp;
using SGFlooringCorp.UI.Workflows;

namespace SGFlooringCorp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            mainMenu.Execute(); 
        }
    }
}
