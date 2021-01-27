using System;
using System.Collections.Generic;
using System.Text;
using EmployeeBusiness.DTOs;
using EmployeeBusiness.Models;
using EmployeeBusiness.Utils;

namespace EmployeeBusiness.Contract
{
    public class MonthlyContract : IContract
    {
        private Employee _employee;
        public MonthlyContract(Employee employee)
        {
            _employee = employee;
        }
        public EmployeeDTO GenerateDTO()
        {
            var dto = new EmployeeDTO();
            PropertyCopier<Employee, EmployeeDTO>.Copy(_employee, dto);
            dto.AnnualSalary = _employee.MonthlySalary * 12;
            return dto;
        }
    }
}
