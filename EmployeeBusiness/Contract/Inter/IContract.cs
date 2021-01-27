using EmployeeBusiness.DTOs;
using EmployeeBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBusiness.Contract
{
    public interface IContract
    {
        EmployeeDTO GenerateDTO();
    }
}
