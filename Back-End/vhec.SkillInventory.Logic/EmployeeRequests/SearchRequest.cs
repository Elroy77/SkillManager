using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;

namespace vhec.SkillInventory.Logic.EmployeeRequests
{
    public class SearchRequest
    {
        public string FullName { get; set; }
        public DetailSkill? DetailSkill { get; set; }
    }
}
