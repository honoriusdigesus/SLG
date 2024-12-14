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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeMapper _employeeMapper;
        private readonly MyValidator _validator;
        private readonly UtilsJwt _utilsJwt;
        private readonly ITokenRepository _tokenRepository;

        public EmployeeService(
            IEmployeeRepository employeeRepository, 
            EmployeeMapper employeeMapper, 
            MyValidator myValidator, 
            UtilsJwt utilsJwt,
            ITokenRepository tokenRepository
            )
        {
            _employeeRepository = employeeRepository;
            _employeeMapper = employeeMapper;
            _validator = myValidator;
            _utilsJwt = utilsJwt;
            _tokenRepository = tokenRepository;
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

        public async Task<int> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new EmployeeException("Incorrect employee ID, please verify.");
            }
            return await _employeeRepository.DeleteAsync(id);
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
            if (_validator.IsValidEmail(employee.Email) && !employee.Password.Equals("") && id > 0)
            {
                employee.Password = _utilsJwt.EncryptPassword(employee.Password);
                var result = _employeeRepository.UpdateAsync(id, _employeeMapper.ToEntity(employee));
                if (result.Result == 0)
                {
                    throw new EmployeeException("Employee not found, please verify your information.");
                }

                return _employeeRepository.UpdateAsync(id, _employeeMapper.ToEntity(employee));
            }
            else
            {
                throw new EmployeeException("Incorrect employee information, please verify.");
            }
        }

        public Task<IActionResult> Login(string document, string password)
        {
            var passwordHash = _utilsJwt.EncryptPassword(password);
            var employee = _employeeRepository.GetEmployeeByDocumentAndPassword(document, passwordHash);
            if (employee == null)
            {
                throw new EmployeeException("Employee not found, please verify your information.");
            }
            var token = _utilsJwt.GenerateJwtToken(_employeeMapper.ToResponse(employee.Result));
            var refreshToken = _utilsJwt.GenerateRefreshToken(employee.Result.EmployeeId);
            var tokenEntity = _tokenRepository.CreateAsync(refreshToken);
            var userResult = _employeeMapper.ToResponse(employee.Result);
            return Task.FromResult(new OkObjectResult(new { userResult, token, refreh = refreshToken.Refreshtoken }) as IActionResult);
        }

        //Refresh token
        public async Task<IActionResult> RefreshToken(string token)
        {
            var tokenEntity = await _tokenRepository.GetByRefreshToken(token);
            if (tokenEntity == null || tokenEntity.Expires < DateTime.Now || tokenEntity.Revoked != null)
            {
                throw new TokenException("Token no válido");
            }
            var employeeId = tokenEntity.EmployeeId;
            var employee = await _employeeRepository.GetByIdAsync((int)employeeId);
            if (employee == null)
            {
                throw new TokenException("El empleado no está registrado");
            }
            var newToken = _utilsJwt.GenerateJwtToken(_employeeMapper.ToResponse(employee));
            var newRefreshToken = _utilsJwt.GenerateRefreshToken((int)employeeId);
            tokenEntity.Revoked = DateTime.Now;
            await _tokenRepository.CreateAsync(newRefreshToken);
            return new OkObjectResult(new { token = newToken, refreshToken = newRefreshToken.Refreshtoken });
        }

    }
}
