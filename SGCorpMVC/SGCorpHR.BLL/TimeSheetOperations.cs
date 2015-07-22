using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpHR.DATA;
using SGCorpHR.Models;
using SGCorpHR.Models.Interfaces;

namespace SGCorpHR.BLL
{
    public class TimeSheetOperations
    {
        private ITimeSheetRepository _timeSheetRepo;

        public TimeSheetOperations(ITimeSheetRepository myTimeSheetRepo)
        {
            _timeSheetRepo = myTimeSheetRepo;
        }


        public List<Employee> GetAllEmployees()
        {
            var repo = new TimeSheetRepository();
            List<Employee> employees = repo.GetAllEmployees();
            
            return employees;
        }

        public Employee SelectOneEmployee(int empId)
        {
            var repo = new TimeSheetRepository();
            Employee employee = new Employee();
            employee = repo.SelectOneEmployee(empId);

            var timeEntries = repo.GetAllTimeEntriesForOneEmp(empId);
            decimal? totalHours = 0;

            foreach (var hours in timeEntries)
            {
                totalHours += hours.HoursWorked;
            }
            employee.TotalHoursWorked = totalHours;

            return employee;
        }

        public Response<List<TimeEntry>> GetAllTimeEntriesForOneEmp(int empId)
        {
            var repo = new TimeSheetRepository();
            Response<List<TimeEntry>> response =  new Response<List<TimeEntry>>();
            List<TimeEntry> timeEntries = repo.GetAllTimeEntriesForOneEmp(empId);
            try
            {
                if (timeEntries.Count > 0)
                {
                    response.Success = true;
                    response.Data = timeEntries;
                }
                else
                {
                    response.Success = false;
                    response.Message = "There are no Time Entries to display.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<TimeEntry> DeleteTimeEntry(int timeEntryId)
        {
            var repo = new TimeSheetRepository();
            Response<TimeEntry> response = new Response<TimeEntry>();
            repo.DeleteTimeEntry(timeEntryId);

            try
            {
                response.Success = true;
                response.Message = "Your Time Entry was deleted.";
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Response<TimeEntry> AddTimeSheets(TimeEntry timeEntry)
        {
            var repo = new TimeSheetRepository();
            Response<TimeEntry> response = new Response<TimeEntry>();
            repo.AddTimeEntry(timeEntry);

            try
            {
                response.Success = true;
                response.Message = "Your Time Entry was added!";
            }
            catch (Exception exception)
            {

                response.Success = false;
                response.Message = exception.Message;
            }
            return response;
        }
    }
}
