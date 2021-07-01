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
        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (var context = new SkillIManagerDbContext(SkillIManagerDbContext.ops.dbOptions))
            {
                employees = await context.employees.ToListAsync();
            }
            return employees;
        }
    }
}
