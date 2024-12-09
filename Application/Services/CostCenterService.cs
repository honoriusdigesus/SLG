using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Exceptions.Types;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.Services
{
    public class CostCenterService : ICostCenterService
    {
        private readonly ICostCenterRepository _costCenterRepository;
        private readonly CostCenterMapper _costCenterMapper;

        public CostCenterService(ICostCenterRepository costCenterRepository, CostCenterMapper costCenterMapper)
        {
            this._costCenterRepository = costCenterRepository;
            this._costCenterMapper = costCenterMapper;
        }
        public async Task<CostCenterRes> CreateAsync(CostCenterReq costCenterReq)
        {
            if (costCenterReq == null || 
                costCenterReq.Costcenternumber.Equals("") || 
                costCenterReq.ProjectmanagerId.Equals("") || 
                costCenterReq.Description.Equals("") ||
                costCenterReq.Costcenternumber<=0
                )
            {
                throw new CostCenterException("CostCenter number, project manager id and description are required");
            }
            var costCenter = _costCenterMapper.ToEntity(costCenterReq);
            var createdCostCenter = await _costCenterRepository.CreateAsync(costCenter);
            return _costCenterMapper.ToResponse(createdCostCenter);
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CostCenterRes>> GetAllAsync()
        {
            return (await _costCenterRepository.GetAllAsync()).Select(_costCenterMapper.ToResponse).ToList();
        }

        public Task<CostCenterRes> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, CostCenterReq costCenterReq)
        {
            throw new NotImplementedException();
        }
    }
}
