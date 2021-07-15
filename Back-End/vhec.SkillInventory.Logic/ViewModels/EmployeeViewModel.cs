using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.DAL.Enums;

namespace vhec.SkillInventory.Logic.ViewModels
{
    class EmployeeViewModel
    {
        public Guid EmployeeId { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public JobPosition JobPosition { get; set; }
        public DateTime DayCreated { get; set; }
        public DetailSkill DetailSkill { get; set; }
    }
}
