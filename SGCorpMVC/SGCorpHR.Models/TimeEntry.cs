using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCorpHR.Models
{
    public class TimeEntry
    {
        public TimeEntry()
        {
            Date = new DateTime();
        }
        
        public int TimeEntryID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public decimal? HoursWorked { get; set; }
        public int EmpID { get; set; }
    }
}
