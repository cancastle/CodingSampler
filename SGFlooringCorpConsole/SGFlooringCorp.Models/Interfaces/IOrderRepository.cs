using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooringCorp.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> ListAll(DateTime orderDate);
        void Add(OrderRequest orderToAdOrderRequest);
    }
}
