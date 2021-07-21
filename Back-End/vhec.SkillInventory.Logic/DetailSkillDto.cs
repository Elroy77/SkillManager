using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vhec.SkillInventory.Logic
{
    public class DetailSkillDto
    {
        public int IdDetail { get; set; }
        public Guid EmployeeID { get; set; }
        public int SkillID { get; set; }
        public int Experience { get; set; }
    }
}
