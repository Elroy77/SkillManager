using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vhec.SkillInventory.Logic;

namespace vhec.SkillInventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private ISkillLogic _skillLogic;

        public SkillController(ISkillLogic skillLogic)
        {
            _skillLogic = skillLogic;
        }
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            var skills = await _skillLogic.GetAllSkillsAsync();
            return Ok(new { data = skills });
        }
    }
}
