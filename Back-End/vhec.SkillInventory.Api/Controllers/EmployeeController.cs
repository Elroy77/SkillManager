using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.Logic;
using vhec.SkillInventory.Logic.EmployeeRequests;
using vhec.SkillInventory.Logic.Requests;

namespace vhec.SkillInventory.Api.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeLogic _employeeLogic;

        public EmployeeController(IEmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees([FromQuery] Paginator filter)
        {
            var employees = await _employeeLogic.GetAllEmployeeAsync(filter);
            return Ok(new { data = employees });
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchEmployees([FromQuery] string fullname, string skillname)
        {
            var employees = await _employeeLogic.SearchEmployeeAsync(fullname, skillname);
            return Ok(new { data = employees });
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var employee = await _employeeLogic.GetByIdAsync(id);
            if (employee == null) return NotFound($"{id} is not found");
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateRequest request)
        {
            var result = await _employeeLogic.CreateEmployeeAsync(request);
            return Ok(result);
        }
        
        [Route("{id:Guid}")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] UpdateRequest request)
        {            
            var result = await _employeeLogic.UpdateEmployeeAsync(id, request);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {

            var result = await _employeeLogic.DeleteEmployeeAsync(id);
            return Ok(result);
        }
        [Route("PositionInventory")]
        [HttpGet]
        public IEnumerable<int> GetPositionInventory()
        {
            var skills = _employeeLogic.GetPositionInventory();
            return skills;
        }
    }
}
