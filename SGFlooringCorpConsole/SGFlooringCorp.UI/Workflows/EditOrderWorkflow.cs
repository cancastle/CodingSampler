using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SGCorpFlooring.BLL;
using SGFlooringCorp.BLL;
using SGFlooringCorp.Models;
using SGFlooringCorp.UI.Utilities;

namespace SGFlooringCorp.UI.Workflows
{
    class EditOrderWorkflow
    {

        public void Execute()
        {
            //get orderDate from user
            //get orderNumber from user
            //display only that order to user using PrintOrderDetails
            OrderRequest newOrderRequest = new OrderRequest();
            OrderOperations ops = OperationsFactory.EditOrderOperations();
            string message = "Please enter an order date in this format(MM/DD/YYYY): ";
            DateTime orderDate = UserInteractions.PromptForDate(message);

            //set up new order
            newOrderRequest.OrderDate = orderDate;
            newOrderRequest.Order = new Order();

            Console.Write("Please enter your order number: ");
            var orderNumber = Console.ReadLine();
            newOrderRequest.Order.OrderNumber = int.Parse(orderNumber);

            //set up old order
            OrderRequest oldOrderRequest = new OrderRequest();
            oldOrderRequest.OrderDate = orderDate;
            oldOrderRequest.Order = new Order();
            oldOrderRequest.Order.OrderNumber = int.Parse(orderNumber);
            Response<Order> oldOrderResponse = ops.GetSelectedOrder(oldOrderRequest);
            oldOrderRequest.Order = oldOrderResponse.Data;


            PrintOrderDetails(oldOrderResponse);
            Console.WriteLine();

            //edit order details
            newOrderRequest = MakeEdits(oldOrderRequest);
            Response<Order> editedOrdeResponse = ops.EditSelectedOrder(newOrderRequest, oldOrderRequest);

            //save response to file
            UserInteractions.PressKeyToContinue();
            PrintOrderDetails(editedOrdeResponse);
            UserInteractions.PressKeyToContinue();

        }

        public OrderRequest MakeEdits(OrderRequest oldOrderRequest)
        {
            //TODO add more ways to check for validity
            Console.WriteLine("Enter change to {0} or press Enter if no change: ", oldOrderRequest.Order.CustomerName);
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key != ConsoleKey.Enter)
            {
                oldOrderRequest.Order.CustomerName = info.Key + Console.ReadLine();
            }
            else
            {
                oldOrderRequest.Order.CustomerName = oldOrderRequest.Order.CustomerName;
                Console.WriteLine();
            }
            //reinstantiating info.Key so that it will not just jump down through the following prompts

            
            Console.WriteLine("Enter change for two-letter State Abbreviation {0} or press enter if no change: ",
                oldOrderRequest.Order.StateAbbreviation);
            ConsoleKeyInfo info2 = Console.ReadKey();
            if (info2.Key != ConsoleKey.Enter)
            {
                oldOrderRequest.Order.StateAbbreviation = info2.Key + Console.ReadLine();
            }
            else
            {
                oldOrderRequest.Order.StateAbbreviation = oldOrderRequest.Order.StateAbbreviation;
                Console.WriteLine();
            }

            
            Console.WriteLine("Enter change for Product Type {0} or press enter if no change: ",
                oldOrderRequest.Order.ProductType);
            ConsoleKeyInfo info3 = Console.ReadKey();
            if (info3.Key != ConsoleKey.Enter)
            {
                oldOrderRequest.Order.ProductType = info3.Key + Console.ReadLine();

            }
            else
            {
                oldOrderRequest.Order.ProductType = oldOrderRequest.Order.ProductType;
                Console.WriteLine();
            }

            
            Console.WriteLine("Enter change for Area {0} or press enter if no change: ", oldOrderRequest.Order.Area);
            ConsoleKeyInfo info4 = Console.ReadKey();
            if (char.IsDigit(info4.KeyChar))
            {
                decimal newArea = decimal.Parse(info4.KeyChar + Console.ReadLine());
                if (newArea != null)
                {
                        //unhandled exception some object to the string that is read in for the number.
                    decimal changedArea = newArea;
                    oldOrderRequest.Order.Area = changedArea;
                }
            }
            else
            {
                    oldOrderRequest.Order.Area = oldOrderRequest.Order.Area;
                    Console.WriteLine();
            }

            return oldOrderRequest;
        }


        private void PrintOrderDetails(Response<Order> response)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Order #{0}", response.Data.OrderNumber);
            Console.WriteLine("Customer Name: {0}", response.Data.CustomerName);
            Console.WriteLine("Product: {0}", response.Data.ProductType);
            Console.WriteLine("State: {0}", response.Data.StateAbbreviation);
            Console.WriteLine("Area: {0:N}, ", response.Data.Area);
            Console.WriteLine("Tax Rate: {0:P}, ", response.Data.TaxRate);
            Console.WriteLine("Total: {0:C} \n\n", response.Data.Total);

        }
    }
}
