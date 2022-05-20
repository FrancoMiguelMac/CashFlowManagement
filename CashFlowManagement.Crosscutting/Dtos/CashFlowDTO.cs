using System;

namespace CashFlowManagement.Crosscutting.Dtos
{
    public class CashFlowDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string CashFlowType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
