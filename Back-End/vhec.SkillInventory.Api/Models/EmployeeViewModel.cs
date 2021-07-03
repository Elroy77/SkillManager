using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.DAL.Enums;

namespace vhec.SkillInventory.Api.Models
{
    public class EmployeeViewModel
    {
        public Guid EmployeeId { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public JobPosition JobPosition { get; set; }
        public DateTime DayCreated { get; set; }
        public DetailSkill DetailSkill { get; set; }
    }
}
