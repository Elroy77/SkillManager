using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vhec.SkillInventory.Logic;
using vhec.SkillInventory.Logic.DetailSkillRequests;

namespace vhec.SkillInventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailSkillController : ControllerBase
    {
        private IDetailSkillLogic _detailSkillLogic;
        public DetailSkillController(IDetailSkillLogic detailSkillLogic)
        {
            _detailSkillLogic = detailSkillLogic;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetailSkill(CreateDetailRequest request)
        {
            var result = await _detailSkillLogic.CreateDetailAsync(request);
            return Ok(result);
        }
    }
}
