using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpFlooring.BLL;
using SGCorpFlooring.Data;
using SGFlooringCorp.Data;
using SGFlooringCorp.Data.Mocks;
using SGFlooringCorp.BLL;
using SGFlooringCorp.Data;

namespace SGFlooringCorp.BLL
{
    public class OperationsFactory
    {
        private static string mode = ConfigurationManager.AppSettings["Mode"];

        public static TaxOperations CreateTaxOperations()
        {
            if (mode == "Test")
                return new TaxOperations(new StateTaxRepositoryMock());
            else
            {
                //return new TaxOperations(new StateTaxReponsitory());
                throw new Exception("Prod repository not yet implemented");
            }
        }

        public static OrderOperations CreateOrderOperations()
        {
            if (mode == "Test")
                return new OrderOperations(new OrderRepository());
            else
            {
                throw new Exception("Prod repository not yet implemented");
            }
        }

        public static OrderOperations DisplayOrderOperations()
        {
            if (mode == "Test")
                return new OrderOperations(new OrderRepository());
            else
            {
                throw new Exception("Prod repository not yet implemented");
            }

        }

        public static ProductOperations CreateProductOperations()
        {
            if(mode == "Test")
                return new ProductOperations(new ProdsMock());

            else
            {
                //return new ProductOperations(new ProductRepository());
                throw new Exception("Prod repository not yet implemented");
            }

        }

        public static OrderOperations EditOrderOperations()
        {
            if (mode == "Test")
                return new OrderOperations(new OrderRepository());
            else
            {
                throw new Exception("Prod repository not yet implemented");
            }
        }

        public static OrderOperations RemoveOrderOperations()
        {
            if (mode == "Test")
                return new OrderOperations(new OrderRepository());
            else
            {
                throw new Exception("Prod repository not yet implemented");
            }
        }

    }
}
