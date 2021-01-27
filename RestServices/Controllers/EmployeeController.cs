using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBusiness.DTOs;
using EmployeeBusiness.Helper;
using EmployeeBusiness.Parameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace RestServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // GET: api/Employee
        [HttpGet]
        public JsonResult GetEmployees()
        {
            var employees = EmployeeHelper.ListEmployeesDTOs();
            return new JsonResult(employees);
        }
        // GET: api/Employee/2
        [HttpGet("{id}")]
        public JsonResult GetEmployees(int id)
        {
            var employee = EmployeeHelper.GetEmployeeDTOById(id);
            if (employee == null)
                return new JsonResult(new object());
            else
                return new JsonResult(employee);
        }
        
        [HttpPost]
        public JsonResult PostEmployees([FromBody] List<ParamEmployeeId> paramEmployeeIds)
        {
            var employees = EmployeeHelper.SearchEmployeesDTOs(paramEmployeeIds);
            return new JsonResult(employees);
        }
    }
}