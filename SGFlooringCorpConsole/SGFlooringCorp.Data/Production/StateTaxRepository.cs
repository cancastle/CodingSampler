using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooringCorp.Models;
using SGFlooringCorp.Models.Interfaces;

namespace SGFlooringCorp.Data.Production
{
    public class StateTaxRepository : IStateTaxRepository
    {
        public List<StateTax> ListAll()
        {
            return new List<StateTax>()
            {
                new StateTax() {StateAbbreviation = "OH", TaxRate = 0.0625M},
                new StateTax() {StateAbbreviation = "PA", TaxRate = 0.0675M},
                new StateTax() {StateAbbreviation = "MI", TaxRate = 0.0575M},
                new StateTax() {StateAbbreviation = "IN", TaxRate = 0.0600M}
            };

        }

    }
}
