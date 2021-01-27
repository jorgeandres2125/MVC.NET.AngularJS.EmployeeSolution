using EmployeeBusiness.Models;
using EmployeeBusiness.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBusiness.Utils
{
    public static class EmployeeUtils
    {
        public static bool BelongsToIds(Employee employee, List<ParamEmployeeId> paramEmployeeIds)
        {
            if (null == employee || null == paramEmployeeIds || paramEmployeeIds.Count == 0) return false;
            else
            {
                var result = paramEmployeeIds.FindAll(objId => (objId.Id == employee.Id));
                if (result == null || result.Count == 0) return false;
                else return true;
            }
        }
    }
}
