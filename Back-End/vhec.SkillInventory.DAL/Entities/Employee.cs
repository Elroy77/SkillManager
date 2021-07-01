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
        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }
        [Required]
        public int Experience { get; set; }
        public Gender Gender { get; set; }
        public DateTime DayCreated { get; set; }
    }
}
