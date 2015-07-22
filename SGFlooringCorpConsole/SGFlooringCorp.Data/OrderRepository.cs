using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooringCorp.Models;
using SGFlooringCorp.Models.Interfaces;

namespace SGCorpFlooring.Data
{
    public class OrderRepository : IOrderRepository
    {
        private const string FilePath = @"DataFiles\Orders";

        public List<Order> ListAll(DateTime orderDate)
        {
            var fullPath = string.Format(@"{0}_{1}.txt", FilePath, orderDate.ToString("MMddyyyy"));

            if (File.Exists(fullPath))
            {
                var orders = new List<Order>();
                var reader = File.ReadAllLines(fullPath);
                for (int i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split(',');

                    var order = new Order();

                    order.OrderNumber = int.Parse(columns[0]);
                    order.CustomerName = columns[1];
                    order.StateAbbreviation = columns[2];
                    order.TaxRate = decimal.Parse(columns[3]);
                    order.ProductType = columns[4];
                    order.Area = decimal.Parse(columns[5]);
                    order.CostPerSquareFoot = decimal.Parse(columns[6]);
                    order.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                    order.MaterialCost = decimal.Parse(columns[8]);
                    order.LaborCost = decimal.Parse(columns[9]);
                    order.Tax = decimal.Parse(columns[10]);
                    order.Total = decimal.Parse(columns[11]);

                    orders.Add(order);
                }

                return orders;

            }
            else
            {
                return null;
            }
        }

        public void Add(OrderRequest orderToAddRequest)
        {
            var orders = ListAll(orderToAddRequest.OrderDate);

            if (orders == null)
                orders = new List<Order>();

            orders.Add(orderToAddRequest.Order);

            OverwriteFile(orders, orderToAddRequest.OrderDate);
        }

        //TODO: need method to either rewrite the file with orders in orderNumber order or display in that order

        public List<Order> RemoveOrder(OrderRequest orderToDeleteRequest)
        {
            var orders = ListAll(orderToDeleteRequest.OrderDate);

            if (orders != null)
            {
                var orderToReplace = orders.FirstOrDefault(x => x.OrderNumber == orderToDeleteRequest.Order.OrderNumber);
                orders.Remove(orderToReplace);
                //TODO: delete the file if there are no more orders
            }

            OverwriteFile(orders, orderToDeleteRequest.OrderDate);
            return orders;
        }


        private void OverwriteFile(List<Order> orders, DateTime orderDate)
        {
            var fullPath = string.Format(@"{0}_{1}.txt", FilePath, orderDate.ToString("MMddyyyy"));

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            using (var writer = File.CreateText(fullPath))
            {
                writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");

                foreach (var order in orders)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                        order.OrderNumber,
                        order.CustomerName,
                        order.StateAbbreviation,
                        order.TaxRate,
                        order.ProductType,
                        order.Area,
                        order.CostPerSquareFoot,
                        order.LaborCostPerSquareFoot,
                        order.MaterialCost,
                        order.LaborCost,
                        order.Tax,
                        order.Total);
                }
            }
        }

        public Order GetOrder(OrderRequest orderRequest)
        {
            var orders = ListAll(orderRequest.OrderDate);
            var selectedOrder = orders.First(x => x.OrderNumber == orderRequest.Order.OrderNumber);
            //needs to handle an exception, but I'm not sure why it is throwing this one.
            return selectedOrder;
        }

        public Order EditOrder(OrderRequest updatedOrderRequest, OrderRequest previousOrderRequest)
        {
            RemoveOrder(previousOrderRequest);
            Add(updatedOrderRequest);
            var order = GetOrder(updatedOrderRequest);
            return order;
        }
    }
}
