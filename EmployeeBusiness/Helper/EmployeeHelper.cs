using EmployeeBusiness.DTOs;
using EmployeeBusiness.Factory;
using EmployeeBusiness.HttpImpl;
using EmployeeBusiness.Models;
using EmployeeBusiness.Parameters;
using EmployeeBusiness.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http.Results;


namespace EmployeeBusiness.Helper
{
    public class EmployeeHelper
    {
        private static string urlClient = "http://masglobaltestapi.azurewebsites.net/api/Employees";

        private static List<Employee> LoadEmployees() {
            RestClient restClient = new RestClient(urlClient);
            restClient.RecuestEmployees().Wait();
            var jsonArray = restClient.getJsonEmployees();
            var listEmployee = jsonArray.ToObject<List<Employee>>();
            return listEmployee;
        }

        public static IEnumerable<EmployeeDTO> ListEmployeesDTOs() 
        {
            var listEmployee = LoadEmployees();
            var listDTO = from emp in listEmployee
                          select ContractFactory.BuildContract(emp).GenerateDTO();
            return listDTO;
        }

       

        public static EmployeeDTO GetEmployeeDTOById(int id)
        {
            var listEmployee = LoadEmployees();
            var listDTO = from emp in listEmployee
                      where emp.Id == id
                      select ContractFactory.BuildContract(emp).GenerateDTO();
            if (listDTO.Any())
            {
                var dto = listDTO.First();
                return dto;
            }
            else return null;
        }

        public static IEnumerable<EmployeeDTO> SearchEmployeesDTOs(List<ParamEmployeeId> paramEmployeeIds)
        {
            var listEmployee = LoadEmployees();
            var listDTO = from emp in listEmployee
                          where EmployeeUtils.BelongsToIds(emp, paramEmployeeIds)
                          select ContractFactory.BuildContract(emp).GenerateDTO();
            return listDTO;
        }
    }
}
