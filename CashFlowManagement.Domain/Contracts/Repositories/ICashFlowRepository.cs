using CashFlowManagement.Domain.Entities;
using System.Collections.Generic;

namespace CashFlowManagement.Domain.Contracts.Repositories
{
    public interface ICashFlowRepository
    {
        void Add(CashFlow cashFlow);
        List<CashFlow> GetAllOfToday();
        decimal GetSumOfCreditsToday();
        decimal GetSumOfDebitsToday();
    }
}
