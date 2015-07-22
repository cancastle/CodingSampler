using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooringCorp.Models;
using SGFlooringCorp.Models;

namespace SGFlooringCorp.UI.Utilities
{
    public class Display
    {
        public static void MainMenu()
        {
            
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("**************** SG Corp Flooring Program ****************");
                Console.WriteLine("*");
                Console.WriteLine("*");
                Console.WriteLine("*");
                Console.Write("*");
                Console.WriteLine("  1. Display Orders");
                Console.Write("*");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  2. Add an Order");
                Console.ResetColor();
                Console.Write("*");
                Console.WriteLine("  3. Edit an Order");
                Console.Write("*");
                Console.WriteLine("  4. Remove an Order");
                Console.Write("*");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  5. Quit");
                Console.ResetColor();
                Console.WriteLine("*");
                Console.WriteLine("*");
                Console.WriteLine("**********************************************************");
        }

        public static void ShowRequestDateForOrder()
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*                           Display Orders ");
            Console.WriteLine("********************************************************************************");
        }

        public static void ShowListOfOrders(Response<List<Order>> response, DateTime orderDate)
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*                           Orders for {0:d} ", orderDate);
            Console.WriteLine("********************************************************************************");
            foreach (var order in response.Data)
            {
                Console.WriteLine("");
                Console.WriteLine(FormatedOrder(order));
                Console.WriteLine("");
                Console.WriteLine("----------------------------------------------------------------");

            }
        }

        public static void ShowDisplayOrdersFailed(Response<List<Order>> response, DateTime orderDate)
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*                  Display orders failed for {0:d} ", orderDate);
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("There was a problem with your request: {0}.", response.Message);
            Console.WriteLine("");
        }


        public static void ShowAddOrder()
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*                           Add Order ");
            Console.WriteLine("********************************************************************************");
        }

        public static void ShowEditOrder()
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*                           Edit Order ");
            Console.WriteLine("********************************************************************************");
        }

        public static void ShowAddOrderConfirmation(Order order)
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*                    Order Added Successfully ");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("You successfully added the order.");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("");
            Console.WriteLine(FormatedOrder(order));
            Console.WriteLine("");
        }

        public static void ShowAddOrderFailed(Response<Order> response)
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*                    Adding Order Failed ");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("The order was not added: {0}.", response.Message);
            Console.WriteLine("");
        }

        public static void ShowConfirmAddOrder(Order order)
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*                      Confirm Add Order ");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("");
            Console.WriteLine(FormatedOrder(order));
            Console.WriteLine("");
        }

        public static void ShowEditOrderConfirmation(Order order)
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*                    Order Edited Successfully ");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("You successfully edited the order.");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("");
            Console.WriteLine(FormatedOrder(order));
            Console.WriteLine("");
        }

        public static void ShowEditOrderFailed(Response<Order> response)
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*                    Editing Order Failed ");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("The order was not edited: {0}.", response.Message);
            Console.WriteLine("");
        }

        private static string FormatedOrder(Order order)
        {
            return string.Format("Order Number:                   {0}" +
                                  "\nCustomer Name:                  {1}" +
                                  "\nProduct Type:                   {2}" +
                                  "\nArea:                           {3}" +
                                  "\nState Abbreviation:             {4}" +
                                  "\nCost Per Square Foot:           {5:C}" +
                                  "\nLabor Cost Per Square Foot:     {6:C}" +
                                  "\nMaterial Cost:                  {7:C}" +
                                  "\nLabor Cost:                     {8:C}" +
                                  "\nTax Rate:                       {9:P}" +
                                  "\nTax:                            {10:C}" +
                                  "\nTotal:                          {11:C}",
                                  order.OrderNumber, order.CustomerName, order.ProductType, order.Area, order.StateAbbreviation, order.CostPerSquareFoot,
                                  order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.TaxRate / 100, order.Tax, order.Total);
        }
    }
}
