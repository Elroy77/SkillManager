using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.DAL.Repositories.Interfaces;
using vhec.SkillInventory.Logic.DetailSkillRequests;

namespace vhec.SkillInventory.Logic
{
    public interface IDetailSkillLogic
    {
        Task<DetailSkillDto> CreateDetailAsync(CreateDetailRequest request);
    }
    public class DetailSkillLogic : IDetailSkillLogic
    {
        private readonly IDetailSkillRepository _detailSkillRepository;
        private readonly IMapper _mapper;

        public DetailSkillLogic(IDetailSkillRepository detailSkillRepository, IMapper mapper)
        {
            _detailSkillRepository = detailSkillRepository;
            _mapper = mapper;
        }
        public async Task<DetailSkillDto> CreateDetailAsync(CreateDetailRequest request)
        {
            var entity = _mapper.Map<DetailSkill>(request);
            var result = await _detailSkillRepository.CreateDetailAsync(entity);
            return _mapper.Map<DetailSkillDto>(result);
        }
    }
}
