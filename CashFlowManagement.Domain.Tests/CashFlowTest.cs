using CashFlowManagement.Domain.Entities;
using CashFlowManagement.Domain.Statics;
using System;
using Xunit;

namespace CashFlowManagement.Domain.Tests
{
    public class CashFlowTest
    {
        private CashFlow _cashFlowMoc;
        public CashFlowTest()
        {
            _cashFlowMoc = new CashFlow("Venda de cerveja", 10.00m, CashFlowTypeStatic.Credit.Id);
        }

        [Fact]
        public void Validate_Control()
        {
            Assert.True(_cashFlowMoc.IsValid());
        }

        [Fact]
        public void Validate_EmptyId()
        {
            _cashFlowMoc.Id = Guid.Empty;
            Assert.False(_cashFlowMoc.IsValid());
        }

        [Fact]
        public void Validate_EmptyDescription()
        {
            _cashFlowMoc.UpdateDescription(string.Empty);
            Assert.False(_cashFlowMoc.IsValid());
        }

        [Fact]
        public void Validate_Description_MaxLength()
        {
            _cashFlowMoc.UpdateDescription("fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff");
            Assert.False(_cashFlowMoc.IsValid());
        }

        [Fact]
        public void Validate_ZeroValue()
        {
            _cashFlowMoc.UpdateValue(decimal.Zero);
            Assert.False(_cashFlowMoc.IsValid());
        }

        [Fact]
        public void Validate_EmptyCashFlowType()
        {
            _cashFlowMoc.UpdateCashflowType(Guid.Empty);
            Assert.False(_cashFlowMoc.IsValid());
        }

        [Fact]
        public void NegativeValueWhenTypeIsDebit()
        {
            _cashFlowMoc.UpdateCashflowType(CashFlowTypeStatic.Debit.Id);
            Assert.Equal(-10.00m, _cashFlowMoc.Value);
        }
    }
}
