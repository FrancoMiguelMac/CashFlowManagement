using CashFlowManagement.Crosscutting.Dtos;
using CashFlowManagement.Domain.Entities;
using CashFlowManagement.Domain.Statics;
using System.Collections.Generic;
using System.Linq;

namespace CashFlowManagement.Application.Extensions
{
    public static class CashFlowExtension
    {
        public static List<CashFlowDTO> ConvertToDTO(this List<CashFlow> entities)
        {
            return entities.Select(ConvertToDTO).ToList();
        }

        public static CashFlowDTO ConvertToDTO(this CashFlow entity)
        {
            return new CashFlowDTO
            {
                Id = entity.Id,
                Description = entity.Description,
                CreatedDate = entity.CreatedDate,
                Value = entity.Value,
                CashFlowType = CashFlowTypeStatic.GetById(entity.CashFlowTypeId).Name
            };
        }
    }
}
