using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCorpHR.Models
{
    public class PolicyDocument
    {
        public PolicyDocument()
        {
            Category = new Category();
        }

        public int PolicyDocumentId { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public Category Category { get; set; }
    }
}
