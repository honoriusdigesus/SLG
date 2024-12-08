using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappers
{
    public class EmployeeMapper
    {
        //From EmployeeReq to Employee
        public Employee ToEntity(EmployeeReq employeeReq)
        {
            return new Employee
            {
                Document = employeeReq.Document,
                Name = employeeReq.Name,
                Lastname = employeeReq.Lastname,
                Email = employeeReq.Email,
                Password = employeeReq.Password,
                Role = employeeReq.Role,
                Phone = employeeReq.Phone,
                ZoneId = employeeReq.ZoneId
            };
        }

        //From Employee to EmployeeRes
        public EmployeeRes ToResponse(Employee employee)
        {
            return new EmployeeRes
            {
                Document = employee.Document,
                Name = employee.Name,
                Lastname = employee.Lastname,
                Email = employee.Email,
                Role = employee.Role,
                Phone = employee.Phone,
                ZoneId = employee.ZoneId
            };
        }
    }
}
