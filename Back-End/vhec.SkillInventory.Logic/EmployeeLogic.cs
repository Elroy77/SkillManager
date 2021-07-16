using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;
using vhec.SkillInventory.DAL.Repositories.Interfaces;
using vhec.SkillInventory.Logic.EmployeeRequests;
using vhec.SkillInventory.Logic.Requests;

namespace vhec.SkillInventory.Logic
{
    public interface IEmployeeLogic
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeeAsync(string fullname);
        Task<EmployeeDto> GetByIdAsync(Guid id);
        Task<EmployeeDto> CreateEmployeeAsync(CreateRequest request);
        Task<EmployeeDto> UpdateEmployeeAsync(Guid id, UpdateRequest request);
        Task<bool> DeleteEmployeeAsync(Guid Id);

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
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeeAsync(string fullname)
        {
            var query = _employeeRepository.GetQuery()
                .FilterByFullname(fullname);
            var result = query.ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider);
            return await Task.FromResult(result);
            //var result = await _employeeRepository.GetAllEmployeeAsync(fullname);
            //return _mapper.Map<IEnumerable<EmployeeDto>>(result);
        }

        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            var result = await _employeeRepository.GetByIdAsync(id);
            return _mapper.Map<EmployeeDto>(result);
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(CreateRequest request)
        {
            var entity = _mapper.Map<Employee>(request);
            var result = await _employeeRepository.CreateEmployeeAsync(entity);
            return _mapper.Map<EmployeeDto>(result);
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(Guid id, UpdateRequest request)
        {
            var entity = await _employeeRepository.GetByIdAsync(id);
            if (entity == null) return new EmployeeDto();
            entity.FullName = request.FullName;
            entity.Gender = request.Gender;
            entity.JobPosition = request.JobPosition;
            var result = await _employeeRepository.UpdateEmployeeAsync(entity);
            return _mapper.Map<EmployeeDto>(result);
        }
        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var entity = await _employeeRepository.GetByIdAsync(id);
            if (entity != null) await _employeeRepository.DeleteEmployeeAsync(entity);
            return await Task.FromResult(entity != null);
        }
    }
    public static partial class EmployeeQueryExtensions
    {
        public static IQueryable<Employee> FilterByFullname(this IQueryable<Employee> source, string fullname)
        {
            return !string.IsNullOrEmpty(fullname) ? source.Where(x => x.FullName.Contains(fullname)) : source;
        }
    }
}
