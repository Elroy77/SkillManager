using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.DAL.Enums;

namespace vhec.SkillInventory.Logic.Requests
{
    public class CreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [MaxLength(250)]
        [Required]
        public string FullName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public JobPosition JobPosition { get; set; }
        public virtual ICollection<DetailSkill> detailSkills { get; set; }
    }
}
