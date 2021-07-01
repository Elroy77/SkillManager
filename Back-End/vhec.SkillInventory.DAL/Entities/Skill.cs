using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vhec.SkillInventory.DAL.Entities
{
    public class Skill
    {
        [Key]
        public int Skill_Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }
        public DateTime DayCreated { get; set; }
    }
}
