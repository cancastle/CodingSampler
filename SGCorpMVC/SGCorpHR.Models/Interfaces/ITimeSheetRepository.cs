using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCorpHR.Models.Interfaces
{
    public interface ITimeSheetRepository
    {
        List<Employee> GetAllEmployees();
        Employee SelectOneEmployee(int empId);
        List<TimeEntry> GetAllTimeEntriesForOneEmp(int empId);
        void DeleteTimeEntry(int timeEntryId);
    }
}
