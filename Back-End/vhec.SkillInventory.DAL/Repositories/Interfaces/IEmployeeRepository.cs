﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;

namespace vhec.SkillInventory.DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetById(Guid id);
        Task<Employee> CreateEmployee(Entities.Employee employee);
        Task<Employee> UpdateEmployee(Entities.Employee employee);
        Task<Employee> DeleteEmployee(Entities.Employee employee);
    }
}