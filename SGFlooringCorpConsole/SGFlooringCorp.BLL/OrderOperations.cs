using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpFlooring.Data;
using SGFlooringCorp.BLL;
using SGFlooringCorp.Data.Mocks;
using SGFlooringCorp.Models;
using SGFlooringCorp.Models.Interfaces;

namespace SGCorpFlooring.BLL
{
    public class OrderOperations
    {
        private IOrderRepository _orderRepo;

        public OrderOperations(IOrderRepository myRepo)
        {
            _orderRepo = myRepo;
        }

        public Response<Order> AddOrder(OrderRequest request)
        {
            var response = new Response<Order>();

            try
            {
                var orders = _orderRepo.ListAll(request.OrderDate);

                int orderNumber = 0;

                if (orders != null)
                    orderNumber = orders.Max(o => o.OrderNumber);

                //Actually, you need to see if there are any orders.  Add one to the highest order number
                orderNumber++;

                request.Order.OrderNumber = orderNumber;

                var tax = OperationsFactory.CreateTaxOperations();
                
                request.Order.TaxRate = tax.GetRate(request.Order.StateAbbreviation);

                var costs = OperationsFactory.CreateProductOperations();
                request.Order.LaborCostPerSquareFoot = costs.GetLaborCostPerSquareFoot(request.Order.ProductType);
                request.Order.CostPerSquareFoot = costs.GetCostPerSquareFoot(request.Order.ProductType);

                request.Order.MaterialCost = (request.Order.Area)*(request.Order.CostPerSquareFoot);

                request.Order.LaborCost = (request.Order.Area)*(request.Order.LaborCostPerSquareFoot);

                request.Order.Tax = ((request.Order.MaterialCost + request.Order.LaborCost)*request.Order.TaxRate);

                request.Order.Total = (request.Order.MaterialCost + request.Order.LaborCost + request.Order.Tax);


                _orderRepo.Add(request);

                response.Success = true;
                response.Data = request.Order;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<Order>> DisplayOrders(DateTime byDate)
        {
            var response = new Response<List<Order>>();
            var orderRepo = new OrderRepository();

            try
            {
                DateTime thisDate = byDate;
                var orders = orderRepo.ListAll(thisDate);
                if (orders != null)
                {
                    response.Success = true;
                    response.Data = orders;
                }
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Order> GetSelectedOrder(OrderRequest selectedOrder)
        {
            var response = new Response<Order>();
            var orderRepo = new OrderRepository();
            Order order = orderRepo.GetOrder(selectedOrder);
            if (order != null)
            {
                response.Success = true;
                response.Data = order;
            }

            return response;
        }

        public Response<Order> EditSelectedOrder(OrderRequest selecteOrder, OrderRequest editedOrderRequest)
        {

            //should be using display orders to get all 
            var selectedOrderResponse = GetSelectedOrder(selecteOrder);
            var repo = new OrderRepository();
            var response = new Response<Order>();
            response.Data = repo.EditOrder(selecteOrder, editedOrderRequest);
            response.Success = true;
            return response;
        }

        public Response<Order> DeleteOrder(OrderRequest request)
        {
            var response = new Response<Order>();
            var orderRepo = new OrderRepository();

            try
            {
                var orders = orderRepo.RemoveOrder(request);
                if (orders != null)
                {
                    response.Success = true;
                    response.Message = "Order successfully deleted!";
                    //it looks like you will get this success message if the request is not null
                }
            }

            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
