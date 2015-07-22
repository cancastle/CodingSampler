using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpFlooring.BLL;
using SGFlooringCorp.BLL;
using SGFlooringCorp.Models;
using SGFlooringCorp.BLL;
using SGFlooringCorp.Models;
using SGFlooringCorp.UI.Utilities;

namespace SGFlooringCorp.UI.Workflows
{
    public class AddOrderWorkflow
    {

        public void Execute()
        {
            Display.ShowAddOrder();
            OrderRequest request = new OrderRequest();
            OrderRequest filledRequest = CreateRequest(request);
            string answer = UserInteractions.PromptUserForConfirmation("Do you wish to save this order?  Y or N: ");
            if (answer == "Y")
            {
                SubmitRequest(filledRequest);
            }
            else
            {
                var menu = new MainMenu();
                menu.Execute();
            }
        }

        private void SubmitRequest(OrderRequest request)
        {
            var ops = OperationsFactory.CreateOrderOperations();
            Response < Order > placedOrder = ops.AddOrder(request);

            if (placedOrder.Success)
            {
                Display.ShowAddOrderConfirmation(placedOrder.Data);
                UserInteractions.PressKeyToContinue();
            }
            else
            {
                Display.ShowAddOrderFailed(placedOrder);
                UserInteractions.PressKeyToContinue();
            }
        }

        public OrderRequest CreateRequest(OrderRequest request)
        {
            request.OrderDate = DateTime.Today;
            request.Order = new Order();
            request.Order.CustomerName = UserInteractions.PromptForRequiredString("Enter Customer Name: ");
            request.Order.StateAbbreviation = UserInteractions.PromptForValidState("Enter two-letter state abbreviation: ");
            request.Order.Area = UserInteractions.PromptForDecimal("Enter area in square feet: ");
            request.Order.ProductType = UserInteractions.PromptForRequiredString("Enter a product type: ");

            return request;
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
