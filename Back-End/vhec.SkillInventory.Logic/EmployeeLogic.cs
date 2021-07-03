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

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            var result = await _employee.GetById(id);
            return result;
        }

        public async Task<Employee> CreateEmployeeAsync(DAL.Entities.Employee employee)
        {
            var result = await _employee.CreateEmployee(employee);
                return result;
        }
        public async Task<Employee> UpdateEmployeeAsync(DAL.Entities.Employee employee)
        {
            var result = await _employee.UpdateEmployee(employee);
            return result;
        }
        public async Task<Employee> DeleteEmployeeAsync(DAL.Entities.Employee employee)
        {
            var result = await _employee.DeleteEmployee(employee);
            return result;
        }
    }
}
