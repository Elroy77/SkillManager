using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;

namespace vhec.SkillInventory.Logic
{
    public class SkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DetailSkill DetailSkill { get; set; }
    }
}
