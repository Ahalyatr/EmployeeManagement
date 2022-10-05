using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Providers.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.Controllers.InternalAPI
{
    [Route("api/internal/employee")]
    [ApiController]
    public class EmployeeInternalApiController : ControllerBase
    {
        private readonly IEmployeeApiClient _employeeApiClient;

        public EmployeeInternalApiController(IEmployeeApiClient employeeApiClient)
        {
            _employeeApiClient = employeeApiClient;
        }

        [HttpGet]
        [Route("{employeeId}")]
        public IActionResult GetEmployeeById([FromRoute] int employeeId)
        {           
                var getEmployeeById = _employeeApiClient.GetEmployeeById(employeeId);
                return Ok(getEmployeeById);            
        }

        [HttpPost]
        [Route("employeeinsert")]

        public IActionResult InsertEmployee([FromBody] EmployeeDetailedViewModel employee)
        {        
                var insertEmployee = _employeeApiClient.InsertEmployee(employee);
                return Ok(employee.Id);           
        }

        [HttpPut]
        [Route("employeeedit")]
        public IActionResult EditEmployee([FromBody] EmployeeDetailedViewModel employee)
        {
                var editEmployee = _employeeApiClient.EditEmployee(employee);
                return Ok(employee.Id);          
        }

        [HttpDelete]
        [Route("{employeeId}")]
        public IActionResult DeleteEmployee([FromRoute] int employeeId)
        {         
                var editEmployee = _employeeApiClient.DeleteEmployee(employeeId);
                return Ok(employeeId);            
        }
    }
}
