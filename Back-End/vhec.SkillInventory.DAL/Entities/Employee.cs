using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Enums;

namespace vhec.SkillInventory.DAL.Entities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string FullName { get; set; }
        [Required]
        public Gender Gender { get; set; }

        public JobPosition JobPosition { get; set; }

        public DateTime DayCreated { get; set; }

        public virtual ICollection<DetailSkill> detailSkills { get; set; }
    }
}
