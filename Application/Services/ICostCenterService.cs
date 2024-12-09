using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services
{
    public interface ICostCenterService
    {
        Task<List<CostCenterRes>> GetAllAsync();
        Task<CostCenterRes> GetByIdAsync(int id);
        Task<CostCenterRes> CreateAsync(CostCenterReq costCenterReq);
        Task<int> UpdateAsync(int id, CostCenterReq costCenterReq);
        Task<int> DeleteAsync(int id);
    }
}
