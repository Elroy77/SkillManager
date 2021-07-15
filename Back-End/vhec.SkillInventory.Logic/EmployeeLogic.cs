using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.DAL.Repositories.Interfaces;
using vhec.SkillInventory.Logic.Requests;

namespace vhec.SkillInventory.Logic
{
    public interface IEmployeeLogic
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<Employee> GetByIdAsync(Guid id);
        Task<EmployeeDto> GetEmployeeAsync(Guid id);
        Task<EmployeeDto> CreateEmployeeAsync(Employee employee);
        Task<EmployeeDto> UpdateEmployeeAsync(Guid id, UpdateRequest request);
        Task<EmployeeDto> DeleteEmployeeAsync(Employee employee);
    }
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeLogic(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var result = await _employeeRepository.GetAllEmployees();
            return _mapper.Map<IEnumerable<EmployeeDto>>(result);
        }
        public async Task<EmployeeDto> GetEmployeeAsync(Guid id)
        {
            var result = await _employeeRepository.GetById(id);
            return _mapper.Map<EmployeeDto>(result);
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return  await _employeeRepository.GetById(id);
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(Employee employee)
        {
            var result = await _employeeRepository.CreateEmployee(employee);
            return _mapper.Map<EmployeeDto>(result);
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(Guid id, UpdateRequest request)
        {
            var employeefromDb = await GetByIdAsync(id);
            if (employeefromDb == null) return new EmployeeDto();
            employeefromDb.FullName = request.FullName;
            employeefromDb.Gender = request.Gender;
            employeefromDb.JobPosition = request.JobPosition;
            var result = await _employeeRepository.UpdateEmployee(employeefromDb);
            return _mapper.Map<EmployeeDto>(result);
        }
        public async Task<EmployeeDto> DeleteEmployeeAsync(Employee employee)
        {
            var result = await _employeeRepository.DeleteEmployee(employee);
            return _mapper.Map<EmployeeDto>(result);
        }
    }
}
