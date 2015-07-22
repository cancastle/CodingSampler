using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooringCorp.Models;
using SGFlooringCorp.Models.Interfaces;


namespace SGFlooringCorp.Data.Mocks
{
    public class ProdsMock : IProdRepository
    {
        public List<Product> ListAll()
        {
            return new List<Product>()
            {
                new Product() {ProductType = "Hardwood", CostPerSquareFoot = 7.55M, LaborCostPerSquareFoot = 4.12M},
                new Product() {ProductType = "Laminate", CostPerSquareFoot = 5.48M, LaborCostPerSquareFoot = 2.96M}
            };
        }
    }
}
