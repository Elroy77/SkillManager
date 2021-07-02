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
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employee.GetAllEmployees();
        }

        public async Task<Boolean> CreateEmployeeAsync(DAL.Entities.Employee employee)
        {
            var result = await _employee.CreateEmployee(employee);
                return true;
        }

        //public async Task<IEnumerable<Employee>> GetEmployeeAsync(Guid id)
        //{
        //    var result = 
        //    return await _employee.GetEmployee(id);
        //}
    }
}
