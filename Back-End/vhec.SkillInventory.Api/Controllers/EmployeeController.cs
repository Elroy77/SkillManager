using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vhec.SkillInventory.Api.Models.EmployeeRequest;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.DAL.Repositories.Functions;
using vhec.SkillInventory.DAL.Repositories.Interfaces;

namespace vhec.SkillInventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
        }
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployees();
            return Ok(new { data = employees });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null) return NotFound($"{id} is not found");
            return Ok(employee);

        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateRequest request)
        {
            var result = await _employeeRepository.CreateEmployee(new DAL.Entities.Employee()
            {
                Id = request.Id,
                FullName = request.FullName,
                Gender = request.Gender,
                JobPosition = request.JobPosition
            });
            return Ok(result);
        }
        
        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] UpdateRequest request)
        {
            var employeefromDb = await _employeeRepository.GetById(id);
            if (employeefromDb == null) return NotFound($"{id} is not found");
            employeefromDb.FullName = request.FullName;
            employeefromDb.Gender = request.Gender;
            employeefromDb.JobPosition = request.JobPosition;
            var result = await _employeeRepository.UpdateEmployee(employeefromDb);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var getId = await _employeeRepository.GetById(id);
            if (getId == null) return NotFound($"{id} is not found");
            var result = await _employeeRepository.DeleteEmployee(getId);
            return Ok(result);
        }

    }
}
