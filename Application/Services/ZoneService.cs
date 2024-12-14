using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Exceptions;
using Application.Exceptions.Types;
using Application.Mappers;
using Application.Utils;
using Domain.Interfaces;

namespace Application.Services
{
    public class ZoneService : IZoneService
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly ZoneMapper _zoneMapper;
        private readonly MyValidator _validator;

        public ZoneService(IZoneRepository zoneRepository, ZoneMapper zoneMapper, MyValidator myValidator)
        {
            _zoneRepository = zoneRepository;
            _zoneMapper = zoneMapper;
            _validator = myValidator;
        }

        public async Task<ZoneRes> CreateAsync(ZoneReq zone)
        {
            if (zone == null || !_validator.ValidateZone(zone.Zonename))
            {
                throw new ZoneException("Zone name is required");
            }

            var zoneEntity = _zoneMapper.ToEntity(zone);
            var createdZone = await _zoneRepository.CreateAsync(zoneEntity);
            return _zoneMapper.ToResponse(createdZone);
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ZoneException("Zone ID is required");
            }
            return await _zoneRepository.DeleteAsync(id);
        }

        public async Task<List<ZoneRes>> GetAllAsync()
        {
            return (await _zoneRepository.GetAllAsync()).Select(_zoneMapper.ToResponse).ToList();
        }

        public async Task<ZoneRes> GetByIdAsync(int id)
        {
            var zone = await _zoneRepository.GetByIdAsync(id) ?? throw new ZoneException($"Zone with ID {id} was not found.");
            return _zoneMapper.ToResponse(zone);
        }

        public async Task<int> UpdateAsync(int id, ZoneReq zone)
        {
            return await _zoneRepository.UpdateAsync(id, _zoneMapper.ToEntity(zone));
        }
    }
}
