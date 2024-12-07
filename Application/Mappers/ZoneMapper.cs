using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Infrastructure.Entities;

namespace Application.Mappers
{
    public class ZoneMapper
    {
        //From ZoneReq to Zone
        public Zone ToEntity(ZoneReq zoneReq)
        {
            return new Zone
            {
                Zonename = zoneReq.Zonename,
                Description = zoneReq.Description
            };
        }

        //From Zone to ZoneRes
        public ZoneRes ToResponse(Zone zone)
        {
            return new ZoneRes
            {
                Zoneid = zone.ZoneId,
                Zonename = zone.Zonename,
                Description = zone.Description
            };
        }
    }
}
