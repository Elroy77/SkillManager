using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vhec.SkillInventory.Api.Models;
using vhec.SkillInventory.Logic;

namespace vhec.SkillInventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeLogic EmployeeLogic = new EmployeeLogic();
        [Route("all")]
        [HttpGet]
        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            List<EmployeeViewModel> employeesList = new List<EmployeeViewModel>();
            var employees = await EmployeeLogic.GetAllEmployees();
            if (employees.Count >= 0)
            {
                foreach (var employee in employees)
                {
                    EmployeeViewModel employeeView = new EmployeeViewModel
                    {
                        EmployeeId = employee.Id,
                        FullName = employee.FullName,
                        Skill = employee.Skill,
                        Experience = employee.Experience,
                        Gender = employee.Gender,
                        DayCreated = employee.DayCreated
                    };
                    employeesList.Add(employeeView);
                }
            }
            return employeesList;
        }
    }
}
