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
        private readonly SkillIManagerDbContext _context;
        public EmployeeRepository(SkillIManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
             var employees = await _context.employees.ToListAsync();
            return employees;
        }
        public async Task<Employee> GetById(Guid id)
        {
            var employeeId = await _context.employees.FindAsync(id);
            return employeeId;
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            _context.employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _context.employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee> DeleteEmployee(Employee employee)
        {
            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}
