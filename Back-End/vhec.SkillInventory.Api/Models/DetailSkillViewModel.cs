using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;

namespace vhec.SkillInventory.Api.Models
{
    public class DetailSkillViewModel
    {
        public int IdDetail { get; set; }
        public Guid EmployeeID { get; set; }
        public int SkillID { get; set; }
        public int Experience { get; set; }
        public EmployeeViewModel Employee { get; set; }


    }
}
