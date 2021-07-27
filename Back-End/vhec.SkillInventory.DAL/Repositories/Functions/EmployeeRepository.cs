using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.DataContext;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.DAL.Repositories.Interfaces;

namespace vhec.SkillInventory.DAL.Repositories.Functions
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SkillManagerDbContext _context;
        public EmployeeRepository(SkillManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync(string fullname)
        {
            IQueryable<Employee> query = _context.employees;
            if (!string.IsNullOrEmpty(fullname))
            {
                query = query.Where(x => x.FullName.Contains(fullname));
            }
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Employee>> SearchEmployeeAsync(string fullname, string skillname)
        {
            var query = (from e in _context.employees
                         join d in _context.detailSkills
                         on e.Id equals d.EmployeeID
                         join s in _context.skills
                         on d.SkillID equals s.Id
                         where e.FullName.Contains(fullname) || s.Name == skillname
                         select e).Distinct().ToListAsync();
            return await query;
        }
        public async Task<Employee> GetByIdAsync(Guid id)
        {
            var employeeId = await _context.employees.FindAsync(id);
            return employeeId;
        }
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            _context.employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _context.employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee> DeleteEmployeeAsync(Employee employee)
        {
            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public IQueryable<Employee> GetQuery()
        {
            return _context.employees.AsQueryable();
        }
        public IEnumerable<int> GetPositionInventory()
        {
            var inventory = (from e in _context.employees  
                             group e by new
                             {
                                 value = e.JobPosition
                             } into si
                             select si.Count());
            return inventory;
        }
    }
}
