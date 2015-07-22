using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooringCorp.Models;
using SGFlooringCorp.Models.Interfaces;

namespace SGFlooringCorp.Data.Production
{
    public class Prods: IProdRepository
    {
        public List<Product> ListAll()
        {
            return new List<Product>()
            {
                new Product() {ProductType = "Carpet", CostPerSquareFoot = 2.25M, LaborCostPerSquareFoot = 2.10M},
                new Product() {ProductType = "Laminate", CostPerSquareFoot = 1.75M, LaborCostPerSquareFoot = 2.10M},
                new Product() {ProductType = "Tile", CostPerSquareFoot = 3.50M, LaborCostPerSquareFoot = 4.15M},
                new Product() {ProductType = "Wood", CostPerSquareFoot = 5.15M, LaborCostPerSquareFoot = 4.75M}
            };
        }
    }
}
