using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vhec.SkillInventory.Api.Models;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.Logic;

namespace vhec.SkillInventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeLogic EmployeeLogic = new EmployeeLogic();
        [Route("listemployee")]
        [HttpGet]
        public async Task<IEnumerable<EmployeeViewModel>> GetAllEmployees()
        {
            List<EmployeeViewModel> employeesList = new List<EmployeeViewModel>();
            var employees = await EmployeeLogic.GetAllEmployeesAsync();
                foreach (var employee in employees)
                {
                    EmployeeViewModel employeeView = new EmployeeViewModel
                    {
                        EmployeeId = employee.Id,
                        FullName = employee.FullName,
                        Gender = employee.Gender,
                        JobPosition = employee.JobPosition,
                        DayCreated = employee.DayCreated,
                    };
                    employeesList.Add(employeeView);
                }
            return employeesList;
        }
        [Route("createemployee")]
        [HttpPost]
        public async Task<Boolean> CreateEmployee(DAL.Entities.Employee employee)
        {
            bool result = await EmployeeLogic.CreateEmployeeAsync(employee);
            return result;
        }
    }
}
