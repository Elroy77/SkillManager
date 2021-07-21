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
    public class DetailSkillRepository : IDetailSkillRepository
    {
        private readonly SkillManagerDbContext _context;
        public DetailSkillRepository(SkillManagerDbContext context)
        {
            _context = context;
        }
        public async Task<DetailSkill> CreateDetailAsync(DetailSkill detailSkill)
        {
            _context.detailSkills.Add(detailSkill);
            await _context.SaveChangesAsync();
            return detailSkill;
        }
    }
}
