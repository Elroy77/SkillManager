using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.DAL.Repositories.Functions;
using vhec.SkillInventory.DAL.Repositories.Interfaces;

namespace vhec.SkillInventory.Logic
{
    public class EmployeeLogic
    {
        private IEmployeeRepository _employee = new EmployeeRepository();
        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> employees = await _employee.GetAllEmployees();
            return employees;
        }
    }
}
