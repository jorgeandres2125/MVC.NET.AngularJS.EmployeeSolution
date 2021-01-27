using EmployeeBusiness.Contract;
using EmployeeBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBusiness.Factory
{
    public static class ContractFactory
    {
        public static IContract BuildContract(Employee employee)
        {
            switch (employee.ContractTypeName) {
                case "HourlySalaryEmployee":
                    return new HourlyContract(employee);
                case "MonthlySalaryEmployee":
                    return new MonthlyContract(employee);
                default :
                    return new HourlyContract(employee);
            }
        }
    }
}
