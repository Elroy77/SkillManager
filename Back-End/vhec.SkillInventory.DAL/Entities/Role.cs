using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vhec.SkillInventory.DAL.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string description { set; get; }
    }
}
