using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.DataContext;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.DAL.Repositories.Functions;
using vhec.SkillInventory.DAL.Repositories.Interfaces;
using vhec.SkillInventory.Logic.ViewModels;

namespace vhec.SkillInventory.Logic
{
    public class EmployeeLogic
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeLogic(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            var result = await _employeeRepository.GetById(id);
            return result;
        }

        public async Task<Employee> CreateEmployeeAsync(DAL.Entities.Employee employee)
        {
            var result = await _employeeRepository.CreateEmployee(employee);
                return result;
        }
        public async Task<Employee> UpdateEmployeeAsync(DAL.Entities.Employee employee)
        {
            var result = await _employeeRepository.UpdateEmployee(employee);
            return result;
        }
        public async Task<Employee> DeleteEmployeeAsync(DAL.Entities.Employee employee)
        {
            var result = await _employeeRepository.DeleteEmployee(employee);
            return result;
        }
    }
}
