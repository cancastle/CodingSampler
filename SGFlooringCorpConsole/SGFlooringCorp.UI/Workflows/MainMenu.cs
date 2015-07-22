using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SGFlooringCorp.UI.Workflows;
using SGFlooringCorp.UI.Utilities;

namespace SGFlooringCorp.UI.Workflows
{
    public class MainMenu
    {
        bool open = true;
        public void Execute()
        {
            
            while (open)
            {
                Display.MainMenu();
                Console.Write("\n\nEnter choice: ");
                string input = Console.ReadLine();
                
                if (input == "5")
                    
                    break;

                ProcessUserChoice(input);
            }
        }

        private void ProcessUserChoice(string input)
        {
            switch (input)
            {
                case "1":
                    var displayOrdersWorkflow = new DisplayOrderWorkflow();
                    displayOrdersWorkflow.Execute();
                    break;
                case "2":
                    var addOrderWorkflow = new AddOrderWorkflow();
                    addOrderWorkflow.Execute();
                    break;
                case "3":
                    var editOrderWorkflow = new EditOrderWorkflow();
                    editOrderWorkflow.Execute();
                    break;
                case "4":
                    var removeOrderWorkflow = new RemoveOrderWorkflow();
                    removeOrderWorkflow.Execute();
                    break;
            }
        }
    }
}
