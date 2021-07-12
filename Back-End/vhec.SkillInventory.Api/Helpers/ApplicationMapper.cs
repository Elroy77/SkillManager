using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vhec.SkillInventory.Api.Models;
using vhec.SkillInventory.DAL.Entities;

namespace vhec.SkillInventory.Api.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }
    }
}
