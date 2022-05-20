using System;
using System.Collections.Generic;
using System.Linq;

namespace CashFlowManagement.Domain.Statics
{
    public class CashFlowTypeStatic
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        /// <summary>
        /// Object instance.
        /// </summary>
        public CashFlowTypeStatic(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static CashFlowTypeStatic Credit = new(Guid.Parse("223c9d39-7635-4625-80e1-a341e0497a0a"), "Crédito");
        public static CashFlowTypeStatic Debit = new(Guid.Parse("7b24b08d-c18a-416b-b17d-704e221c8bb7"), "Débito");

        public static List<CashFlowTypeStatic> GetAll() => new() { Credit, Debit };

        public static CashFlowTypeStatic GetById(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
