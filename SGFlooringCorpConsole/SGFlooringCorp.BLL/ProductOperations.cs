using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooringCorp.Models;
using SGFlooringCorp.Models.Interfaces;

namespace SGFlooringCorp.BLL
{
    public class ProductOperations
    {
        private IProdRepository _productRepository;

        public ProductOperations(IProdRepository myProdRepo)
        {
            _productRepository = myProdRepo;
        }

        public List<Product> ListAll()
        {
            return _productRepository.ListAll();
        }

        public string GetProductType(string productType)
        {
            var allProducts = _productRepository.ListAll();
            var product = allProducts.First(p => p.ProductType == productType);

            return product.ProductType;
        }

        public bool IsValidProductType(string productType)
        {
            var allProducts = _productRepository.ListAll();
            return allProducts.Any(p => p.ProductType == productType);
        }

        public  decimal GetCostPerSquareFoot(string productType)
        {
            var allProducts = _productRepository.ListAll();
            var product = allProducts.First(p => p.ProductType == productType);

            return product.CostPerSquareFoot;
        }

        public  decimal GetLaborCostPerSquareFoot(string productType)
        {
            var allProducts = _productRepository.ListAll();
            var product = allProducts.First(p => p.ProductType == productType);

            return product.LaborCostPerSquareFoot;
        }
    }
}
