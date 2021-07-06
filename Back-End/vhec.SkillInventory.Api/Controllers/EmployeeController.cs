using Microsoft.AspNetCore.Cors;
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
        public async Task<IActionResult> GetAllEmployees()
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
            //return employeesList;
            return Ok(new { data = employeesList });
        }

        [HttpGet]
        [Route("list/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var employee = await EmployeeLogic.GetByIdAsync(id);
            if (employee == null) return NotFound($"{id} is not found");
            return Ok(new EmployeeViewModel {
                EmployeeId = employee.Id,
                FullName = employee.FullName,
                Gender = employee.Gender,
                JobPosition = employee.JobPosition,
                DayCreated = employee.DayCreated
            });
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateRequest request)
        {
            var result = await EmployeeLogic.CreateEmployeeAsync(new DAL.Entities.Employee() 
            {
                Id = request.Id,
                FullName = request.FullName,
                Gender = request.Gender,
                JobPosition = request.JobPosition,
                DayCreated = request.DayCreated
            });
            return Ok(result);
        }

        [Route("update/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] UpdateRequest request)
        {
            var employeefromDb = await EmployeeLogic.GetByIdAsync(id);
            if (employeefromDb == null) return NotFound($"{id} is not found");
            employeefromDb.FullName = request.FullName;
            employeefromDb.Gender = request.Gender;
            employeefromDb.JobPosition = request.JobPosition;
            employeefromDb.DayCreated = request.DayCreated;
            var result = await EmployeeLogic.UpdateEmployeeAsync(employeefromDb);
            return Ok(new EmployeeViewModel {
                EmployeeId = result.Id,
                FullName = result.FullName,
                Gender = result.Gender,
                JobPosition = result.JobPosition,
                DayCreated = result.DayCreated
            });
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var getId = await EmployeeLogic.GetByIdAsync(id);
            if (getId == null) return NotFound($"{id} is not found");
            var result = await EmployeeLogic.DeleteEmployeeAsync(getId);
            return Ok(new EmployeeViewModel
            {
                EmployeeId = result.Id,
                FullName = result.FullName,
                Gender = result.Gender,
                JobPosition = result.JobPosition,
                DayCreated = result.DayCreated
            });
        }

    }
}
