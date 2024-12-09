using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappers
{
    public class CostCenterMapper
    {
        //From Request to Entity
        public Costcenter ToEntity(CostCenterReq costCenterReq)
        {
            return new Costcenter
            {
                Costcenternumber = costCenterReq.Costcenternumber,
                Description = costCenterReq.Description,
                ProjectmanagerId = costCenterReq.ProjectmanagerId
            };
        }

        //From Entity to Response
        public CostCenterRes ToResponse(Costcenter costcenter)
        {
            return new CostCenterRes
            {
                CostcenterId = costcenter.CostcenterId,
                CostCenterNumber = (int)costcenter.Costcenternumber,
                Description = costcenter.Description,
                ProjectManagerId = (int)costcenter.ProjectmanagerId
            };
        }
    }
}

/*
 * public int? Costcenternumber { get; set; }

    public string? Description { get; set; }

    public int? ProjectmanagerId { get; set; }
 
        public int CostcenterId { get; set; }
        public int CostCenterNumber { get; set; }
        public string? Description { get; set; }
        public int ProjectManagerId { get; set; }

 */