using System;

namespace CashFlowManagement.Crosscutting.Dtos
{
    public class CashFlowFormDTO
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public Guid CashFlowTypeId { get; set; }
    }
}
