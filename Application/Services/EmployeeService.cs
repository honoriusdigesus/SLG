using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Exceptions.Types;
using Application.Mappers;
using Application.Utils;
using Domain.Interfaces;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeMapper _employeeMapper;
        private readonly MyValidator _validator;
        private readonly UtilsJwt _utilsJwt;

        public EmployeeService(IEmployeeRepository employeeRepository, EmployeeMapper employeeMapper, MyValidator myValidator, UtilsJwt utilsJwt)
        {
            _employeeRepository = employeeRepository;
            _employeeMapper = employeeMapper;
            _validator = myValidator;
            _utilsJwt = utilsJwt;
        }

        public async Task<EmployeeRes> CreateAsync(EmployeeReq employee)
        {
            // Validamos que el objeto no sea nulo y que el nombre no sea nulo o vacío, además del correo
            if (employee == null || !_validator.IsValidEmail(employee.Email) || employee.Password.Equals(""))
            {
                throw new EmployeeException("Incorrect employee information, please verify.");
            }
            //Encriptamos la contraseña
            employee.Password = _utilsJwt.EncryptPassword(employee.Password);
            return _employeeMapper.ToResponse(await _employeeRepository.CreateAsync(_employeeMapper.ToEntity(employee)));
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeRes>> GetAllAsync()
        {
            return (await _employeeRepository.GetAllAsync()).Select(_employeeMapper.ToResponse).ToList();
        }

        public async Task<EmployeeRes> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new EmployeeException("Incorrect employee ID, please verify.");
            }
            return _employeeMapper.ToResponse(await _employeeRepository.GetByIdAsync(id));
        }

        public Task<int> UpdateAsync(int id, EmployeeReq employee)
        {
            throw new NotImplementedException();
        }
    }
}
