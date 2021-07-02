using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vhec.SkillInventory.Api.Models;
using vhec.SkillInventory.Api.Models.EmployeeRequest;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.DAL.Repositories.Interfaces;
using vhec.SkillInventory.Logic;

namespace vhec.SkillInventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeLogic EmployeeLogic = new EmployeeLogic();
        [Route("list")]
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

        [HttpGet]
        [Route("list/{id}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            var employee = await EmployeeLogic.GetByIdAsync(id);
            if (employee == null) return NotFound($"{id} is not found");
            return Ok(employee);
        }

        [Route("create")]
        [HttpPost]
        public async Task<Boolean> CreateEmployee(Employee employee)
        {
            bool result = await EmployeeLogic.CreateEmployeeAsync(employee);
            return result;
        }

        [Route("update/{id}")]
        [HttpPut]
        public async Task<Boolean> UpdateEmployee([FromRoute] Guid id, [FromBody] UpdateRequest request)
        {
            var employeefromDb = await EmployeeLogic.GetByIdAsync(id);
            if (employeefromDb == null) return false;
            employeefromDb.FullName = request.FullName;
            employeefromDb.Gender = request.Gender;
            employeefromDb.JobPosition = request.JobPosition;
            bool result = await EmployeeLogic.UpdateEmployeeAsync(employeefromDb);
            return result;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<Boolean> DeleteEmployee([FromRoute] Guid id)
        {
            var getId = await EmployeeLogic.GetByIdAsync(id);
            if (getId == null) return false;
            bool result = await EmployeeLogic.DeleteEmployeeAsync(getId);
            return result;
        }

    }
}
