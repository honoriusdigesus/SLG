﻿using System;
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
    public class ZoneService : IZoneServices
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

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ZoneRes>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ZoneRes> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, ZoneReq zone)
        {
            throw new NotImplementedException();
        }
    }
}
