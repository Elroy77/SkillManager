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
    public class SkillRepository : ISkillRepository
    {
        private readonly SkillManagerDbContext _context;
        public SkillRepository(SkillManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetAllSkills()
        {
            var skills = await _context.skills.ToListAsync();
            return skills;
        }

        public IEnumerable<string> GetSkillName()
        {
            var name = (from e in _context.employees
                        join d in _context.detailSkills
                        on e.Id equals d.EmployeeID
                        join s in _context.skills
                        on d.SkillID equals s.Id
                        select s.Name).Distinct();
            return name.ToList();
        }
        public IEnumerable<int> GetSkillInventory()
        {
            var inventory = (from e in _context.employees
                             join d in _context.detailSkills
                             on e.Id equals d.EmployeeID
                             join s in _context.skills
                             on d.SkillID equals s.Id
                             group s by new
                             {
                                 name = s.Name
                             } into si
                             select si.Count());
            return inventory;
        }
    }
}
