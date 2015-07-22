using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooringCorp.BLL;
using SGFlooringCorp.Models;
using SGFlooringCorp.UI.Utilities;

namespace SGFlooringCorp.UI.Workflows
{
    class RemoveOrderWorkflow
    {
        public void Execute()
        {
            OrderRequest request = new OrderRequest();
            request = OrderToRemoveInformation();
            RemoveOrder(request);

        }

        public OrderRequest OrderToRemoveInformation()
        {
            var request = new OrderRequest();

            string message = "Please enter an order date in this format(MM/DD/YYYY): ";
            DateTime orderDate = UserInteractions.PromptForDate(message);
            request.OrderDate = orderDate;
            request.Order = new Order();
            Console.WriteLine("Please enter an order number");
            request.Order.OrderNumber = int.Parse(Console.ReadLine());

            return request;
        }

        public void RemoveOrder(OrderRequest request)
        {
            var ops = OperationsFactory.RemoveOrderOperations();
            var response = ops.DeleteOrder(request);

            Console.Clear();
            if (response.Success)
            {
                Console.WriteLine(response.Message);
                UserInteractions.PressKeyToContinue();
            }
            else
            {
                Console.WriteLine(response.Message);
                UserInteractions.PressKeyToContinue();
            }
        }
    }
}

