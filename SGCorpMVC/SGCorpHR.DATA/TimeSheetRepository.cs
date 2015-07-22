using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SGCorpHR.DATA.Config;
using SGCorpHR.Models;
using SGCorpHR.Models.Interfaces;

namespace SGCorpHR.DATA
{
    public class TimeSheetRepository : ITimeSheetRepository
    {
        public List<Employee> GetAllEmployees()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var employees = cn.Query<Employee>("SELECT * FROM Employee").ToList();

                return employees;
            }
        }

        public Employee SelectOneEmployee(int empId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("EmployeeID", empId);
                Employee employee = new Employee();
                employee = cn.Query<Employee>("GetEmployee", p, commandType: CommandType.StoredProcedure).ToList().FirstOrDefault();

                return employee;
            }
        }

        public List<TimeEntry> GetAllTimeEntriesForOneEmp(int empId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("EmpID", empId);
                var timeEntries = cn.Query<TimeEntry>("GetAllTimeEntriesForOneEmp", p, commandType: CommandType.StoredProcedure).ToList();

                return timeEntries;
            }
        }

        public void DeleteTimeEntry(int timeEntryId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("TimeEntryID", timeEntryId);
                cn.Execute("DeleteTimeEntry", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddTimeEntry(TimeEntry timeEntry)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("EmpID", timeEntry.EmpID);
                p.Add("Date", timeEntry.Date);
                p.Add("HoursWorked", timeEntry.HoursWorked);

                cn.Execute("AddTimeEntry", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
