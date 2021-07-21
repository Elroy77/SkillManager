using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vhec.SkillInventory.Logic.DetailSkillRequests
{
    public class CreateDetailRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetail { get; set; }
        public Guid EmployeeID { get; set; }
        public int SkillID { get; set; }
        [Required]
        public int Experience { get; set; }

    }
}
