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
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (var context = new SkillIManagerDbContext(SkillIManagerDbContext.ops.dbOptions))
            {
                employees = await context.employees.ToListAsync();
            }
            return employees;
        }
        public async Task<Employee> GetById(Guid id)
        {
            using (var context = new SkillIManagerDbContext(SkillIManagerDbContext.ops.dbOptions))
            {
                return await context.employees.FindAsync(id);
            }
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            Employee newemployee = new Employee()
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Gender = employee.Gender,
                JobPosition = employee.JobPosition,
                DayCreated = employee.DayCreated,
                detailSkills = employee.detailSkills
            };
            using (var context = new SkillIManagerDbContext(SkillIManagerDbContext.ops.dbOptions))
            {
                await context.employees.AddAsync(newemployee);
                await context.SaveChangesAsync();
            }
            return newemployee;
        }
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            using (var context = new SkillIManagerDbContext(SkillIManagerDbContext.ops.dbOptions))
            {
                context.employees.Update(employee);
                await context.SaveChangesAsync();
            }
            return employee;
        }
        public async Task<Employee> DeleteEmployee(Employee employee)
        {
            using (var context = new SkillIManagerDbContext(SkillIManagerDbContext.ops.dbOptions))
            {
                context.employees.Remove(employee);
                await context.SaveChangesAsync();
            }
            return employee;
        }
    }
}
