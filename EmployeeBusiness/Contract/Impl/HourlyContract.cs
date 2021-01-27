using System;
using System.Collections.Generic;
using System.Text;
using EmployeeBusiness.DTOs;
using EmployeeBusiness.Models;
using EmployeeBusiness.Utils;

namespace EmployeeBusiness.Contract
{
    public class HourlyContract : IContract
    {
        private Employee _employee;
        public HourlyContract(Employee employee)
        {
            _employee = employee;
        }

        public EmployeeDTO GenerateDTO()
        {
            var dto = new EmployeeDTO();
            PropertyCopier<Employee, EmployeeDTO>.Copy(_employee, dto);
            dto.AnnualSalary = 120 * _employee.HourlySalary * 12;
            return dto;
        }
    }
}
