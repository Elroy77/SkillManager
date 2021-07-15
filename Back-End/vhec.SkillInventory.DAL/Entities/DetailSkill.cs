using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vhec.SkillInventory.DAL.Entities
{
    public class DetailSkill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetail { get; set; }
        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public int SkillID { get; set; }
        public Skill Skill { get; set; }
        public int Experience { get; set; }

    }
}
