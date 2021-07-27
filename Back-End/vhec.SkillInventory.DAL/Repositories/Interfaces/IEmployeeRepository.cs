using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;

namespace vhec.SkillInventory.DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeeAsync(string fullname);
        Task<IEnumerable<Employee>> SearchEmployeeAsync(string fullname, string skillname);
        Task<Employee> GetByIdAsync(Guid id);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<Employee> DeleteEmployeeAsync(Employee employee);
        public IQueryable<Employee> GetQuery();
        IEnumerable<int> GetPositionInventory();
    }
}
