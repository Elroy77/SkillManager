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
        private readonly SkillIManagerDbContext _context;
        public SkillRepository(SkillIManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetAllSkills()
        {
            var skills = await _context.skills.ToListAsync();
            return skills;
        }
    }
}
