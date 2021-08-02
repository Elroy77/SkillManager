using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vhec.SkillInventory.Logic.LoginRequests
{
    public class LoginResponse
    {
        public bool Successful { set; get; }
        public string Error { set; get; } 
        public string Token { set; get; }
    }
}
