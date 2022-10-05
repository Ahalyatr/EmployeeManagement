using EmployeeManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.DataAccess.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeData> GetEmployees();
        EmployeeData GetEmployeeById(int id);
        bool InsertEmployee(EmployeeData employee);
        bool EditEmployee(EmployeeData employee);
        bool DeleteEmployee(int employeeId);
    }
}
