using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorpHR.Models;

namespace SGCorpHR.UI.Models
{
    public class AddTimeSheetVM
    {
        public List<SelectListItem> Employees { get; set; }
        public int SelectedEmployeeID { get; set; }
        public Employee employee { get; set; }
        public TimeEntry timeEntry { get; set; }
        public List<TimeEntry> TimeEntries { get; set; } 
        public string Message { get; set; }

        public void CreateEmployeeList(List<Employee> employees)
        {
            Employees = new List<SelectListItem>();
            foreach (var e in employees)
            {
                Employees.Add(new SelectListItem()
                {
                    Text = e.LastName + ", " + e.FirstName,
                    Value = e.EmpID.ToString()

                });
            }
        }
    }
}