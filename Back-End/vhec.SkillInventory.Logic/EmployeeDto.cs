using System;
using System.Collections.Generic;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.DAL.Enums;

namespace vhec.SkillInventory.Logic
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public JobPosition JobPosition { get; set; }
        public DateTime DayCreated { get; set; }
        public ICollection<DetailSkill> DetailSkill { get; set; }
    }
}
