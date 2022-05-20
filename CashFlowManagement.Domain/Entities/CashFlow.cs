﻿using CashFlowManagement.Domain.Core.Models;
using CashFlowManagement.Domain.Statics;
using CashFlowManagement.Domain.Validations;
using System;

namespace CashFlowManagement.Domain.Entities
{
    public class CashFlow : AuditEntity
    {
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public Guid CashFlowTypeId { get; private set; }

        /// <summary>
        /// Object instance.
        /// </summary>
        public CashFlow(string description, decimal value, Guid cashFlowTypeId)
        {
            if (cashFlowTypeId == CashFlowTypeStatic.Debit.Id)
                value *= -1;

            Description = description;
            Value = value;
            CashFlowTypeId = cashFlowTypeId;
        }

        public override bool IsValid()
        {
            ValidationResult = new CashFlowValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
