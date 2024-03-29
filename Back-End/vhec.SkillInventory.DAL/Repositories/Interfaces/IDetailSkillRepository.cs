﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;

namespace vhec.SkillInventory.DAL.Repositories.Interfaces
{
    public interface IDetailSkillRepository
    {
        Task<DetailSkill> CreateDetailAsync(DetailSkill detailSkill);
    }
}
