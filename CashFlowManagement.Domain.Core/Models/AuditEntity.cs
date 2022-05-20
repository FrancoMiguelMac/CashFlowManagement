using System;

namespace CashFlowManagement.Domain.Core.Models
{
    public abstract class AuditEntity : Entity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        protected AuditEntity()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
    }
}
