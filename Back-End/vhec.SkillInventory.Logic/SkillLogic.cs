using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Repositories.Interfaces;

namespace vhec.SkillInventory.Logic
{
    public interface ISkillLogic
    {
        Task<IEnumerable<SkillDto>> GetAllSkillsAsync();
        IEnumerable<string> GetSkillNameAsync();
        IEnumerable<int> GetSkillInventoryAsync();
    }
    public class SkillLogic : ISkillLogic
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public SkillLogic(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SkillDto>> GetAllSkillsAsync()
        {
            var result = await _skillRepository.GetAllSkills();
            return _mapper.Map<IEnumerable<SkillDto>>(result);
        }

        public IEnumerable<string> GetSkillNameAsync()
        {
            var result = _skillRepository.GetSkillName();
            return result;
        }
        public IEnumerable<int> GetSkillInventoryAsync()
        {
            var result = _skillRepository.GetSkillInventory();
            return result;
        }
    }
}
