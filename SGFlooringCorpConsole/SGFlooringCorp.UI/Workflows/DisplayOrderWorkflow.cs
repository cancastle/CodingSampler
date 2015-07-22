using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooringCorp.Data;
using SGFlooringCorp.Models;
using SGFlooringCorp.BLL;
using SGFlooringCorp.UI.Workflows;
using SGFlooringCorp.UI.Utilities;


namespace SGFlooringCorp.UI.Workflows
{
    class DisplayOrderWorkflow
    {
        public List<Order> AllOrders = new List<Order>();

        public void Execute()
        {

            DateTime orderDate = new DateTime();
            
            orderDate = GetDateForOrdersToDisplay();

            AllOrders = DisplayAllOrdersForTheDay(orderDate);

            PrintOrderDetails(AllOrders);

        }

        public DateTime GetDateForOrdersToDisplay()
        {
            string message = "Please enter an order date in this format(MM/DD/YYYY): ";
            DateTime orderDate = UserInteractions.PromptForDate(message);
            
            return orderDate;
        }


        public List<Order> DisplayAllOrdersForTheDay(DateTime thisDate)
        {
            var ops = OperationsFactory.DisplayOrderOperations();
            var response = ops.DisplayOrders(thisDate);
            if (response.Success)
            {
                AllOrders = response.Data;
            }
            Console.WriteLine(response.Message);

            return AllOrders;
        }


        private static void PrintOrderDetails(List<Order> allOrders)
        {
            Console.Clear();

            if (allOrders != null)
            {
                //place a header row here
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Order No." + "       Customer Name" + "     Product" + "  State Tax" + "    Area" + "        Total");
                Console.WriteLine();
                Console.ResetColor();
                foreach (var item in allOrders)
                {
                    Console.Write("Order #{0}: ", item.OrderNumber);
                    Console.Write("{0,20}, ", item.CustomerName);
                    Console.Write("{0,10}, " , item.ProductType);
                    Console.Write("{0}, ", item.StateAbbreviation);
                    Console.Write("{0:P}, ", item.TaxRate);
                    Console.Write("{0:N}, ", item.Area);
                    Console.Write("     {0:C} \n\n", item.Total);

                }
            }
            else
            {
                Console.WriteLine("No orders could be found for that date.");
                UserInteractions.PressKeyToContinue();
            }
            
            UserInteractions.PressKeyToContinue();

        }

    }
}
