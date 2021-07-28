using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vhec.SkillInventory.Logic.EmployeeRequests
{
    public class Paginator
    {
        public int perpage { set; get; }
        public int currentpage { set; get; }
        public  Paginator()
        {
            this.perpage = 3;
            this.currentpage = 1;
        }
        public Paginator(int perpage, int currentpage)
        {
            this.perpage = perpage > 5 ? 5 : perpage;
            this.currentpage = currentpage < 1 ? 1 : currentpage;
        }
    }
}
