using EmployeeManagement.API.Models;
using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeApiController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        /// get employee by calling GetEmployeeById() in IEmployeeService and store it in a variable and Map that variable to EmployeeDetailedViewModel.

        [HttpGet]
        [Route("employees")]
        public IActionResult GetEmployees()
        {
            try
            {                                 
                var getEmployeeViewModel =  _employeeService.GetEmployees();
                return Ok(MapToGetEmployee(getEmployeeViewModel));
            }
            catch (Exception )
            {
                throw;
            }     
        }
        private IEnumerable<EmployeeDetailedViewModel> MapToGetEmployee(IEnumerable<EmployeeDto> listOfEmployees)
        {
            var employeeList = new List<EmployeeDetailedViewModel>();
            foreach (var item in listOfEmployees)
            {
                var employee = new EmployeeDetailedViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Department = item.Department,
                    Age = item.Age,
                    Address = item.Address
                };
                employeeList.Add(employee);
            }
            return employeeList;
        }

        [HttpGet]
        [Route("employees/{employeeId}")]
        public IActionResult GetEmployeeById([FromRoute] int employeeId)
        {
            try
            {                 
                var getEmployeeByIdViewModel = _employeeService.GetEmployeeById(employeeId);
                return Ok(MapToGetEmployeeById(getEmployeeByIdViewModel));
            }
            catch (Exception)
            {
                throw;
            }
        }
        private EmployeeDetailedViewModel MapToGetEmployeeById(EmployeeDto employees)
        {
            try
            {
                var employee = new EmployeeDetailedViewModel
                {
                    Id = employees.Id,
                    Name = employees.Name,
                    Department = employees.Department,
                    Age = employees.Age,
                    Address = employees.Address
                };
                return employee;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("employeeinsert")]
        public IActionResult InsertEmployee([FromBody] EmployeeDetailedViewModel employee)
        {
            try
            {
                var insertEmployeeViewModel = _employeeService.InsertEmployee(MapToInsertEmployee(employee));
                return Ok(insertEmployeeViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private EmployeeDto MapToInsertEmployee(EmployeeDetailedViewModel employee)
        {
            try
            {
                var employees = new EmployeeDto
                {
                    Name = employee.Name,
                    Department = employee.Department,
                    Age = employee.Age,
                    Address=employee.Address
                };
                return employees;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("employeeedit")]
        public IActionResult EditEmployee([FromBody] EmployeeDetailedViewModel employee)
        {
            try
            {
                var editEmployeeViewModel = _employeeService.EditEmployee(MapToEditEmployee(employee));
                //return Ok(editEmployeeViewModel);
                if (editEmployeeViewModel)
                {
                    return Ok(editEmployeeViewModel);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private EmployeeDto MapToEditEmployee(EmployeeDetailedViewModel employee)
        {
            try
            {
                var employees = new EmployeeDto
                {
                    Id = employee.Id,
                    Name = employee.Name,                   
                    Department = employee.Department,
                    Age=employee.Age,
                    Address = employee.Address
                };
                return employees;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("employeedelete/{employeeId}")]
        public IActionResult DeleteEmployee([FromRoute] int employeeId)
        {
            try
            {
                var deleteEmployeeViewModel = _employeeService.DeleteEmployee(employeeId);
                return Ok(deleteEmployeeViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
