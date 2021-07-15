using AutoMapper;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.Logic;
using vhec.SkillInventory.Logic.Requests;

namespace vhec.SkillInventory.Api.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<CreateRequest, Employee>().ReverseMap();
        }
    }
}
