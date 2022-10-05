using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEnumerable<EmployeeDto> GetEmployees()
        {
            try
            {
                var getEmployee = _employeeRepository.GetEmployees();
                return MapToEmployeeDtoGetAll(getEmployee);
            }
            catch (System.Exception)
            {
                throw;
            }   
        }

        private List<EmployeeDto> MapToEmployeeDtoGetAll(IEnumerable<EmployeeData> listOfEmployees)
        {
            try
            {
                var employeeList = new List<EmployeeDto>();
                foreach(var item in listOfEmployees)
                {
                    var employee = new EmployeeDto
                    {
                        Id = item.Id,
                        Name= item.Name,
                        Department= item.Department,
                        Age= item.Age,
                        Address= item.Address
                    };
                    employeeList.Add(employee);
                }
                return employeeList;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public EmployeeDto GetEmployeeById(int employeeId)
        {
            try
            {
                var getEmployeeById = _employeeRepository.GetEmployeeById(employeeId);
                return MapToEmployeeDtoById(getEmployeeById);
            }
            catch (System.Exception)
            {
                throw;
            }           
        }
        private EmployeeDto MapToEmployeeDtoById(EmployeeData employees)
        {
            try
            {
                var employee = new EmployeeDto
                {
                    Id = employees.Id,
                    Name = employees.Name,
                    Department=employees.Department,
                    Age=employees.Age,
                    Address=employees.Address       
                };
                return employee;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool InsertEmployee(EmployeeDto employee)
        {
            try
            {
                var insertEmployee = _employeeRepository.InsertEmployee(MapToEmployeeDtoInsert(employee));
                return insertEmployee;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private EmployeeData MapToEmployeeDtoInsert(EmployeeDto employee)
        {
            try
            {
                var employees = new EmployeeData
                {
                    Name=employee.Name,
                    Department=employee.Department,
                    Age=employee.Age,
                    Address=employee.Address
                };
                return employees;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool EditEmployee(EmployeeDto employee)
        {
            try
            {
                var editEmployee = _employeeRepository.EditEmployee(MapToEmployeeDtoEdit(employee));
                return editEmployee;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private EmployeeData MapToEmployeeDtoEdit(EmployeeDto employee)
        {
            try
            {
                var employees = new EmployeeData()
                {
                    Id=employee.Id,
                    Name = employee.Name,
                    Department = employee.Department,
                    Age = employee.Age,
                    Address = employee.Address
                };
                return employees;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                var deleteEmployee = _employeeRepository.DeleteEmployee(employeeId);
                return deleteEmployee;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
