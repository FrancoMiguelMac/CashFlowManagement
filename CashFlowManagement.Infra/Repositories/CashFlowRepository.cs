using CashFlowManagement.Domain.Contracts.Repositories;
using CashFlowManagement.Domain.Entities;
using CashFlowManagement.Domain.Statics;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CashFlowManagement.Infra.Repositories
{
    public class CashFlowRepository : ICashFlowRepository
    {
        private readonly IMemoryCache _memoryCache;
        private const string CASHFLOW_KEY = "CashFlowKey";

        public CashFlowRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add(CashFlow cashFlow)
        {
            if (_memoryCache.TryGetValue(CASHFLOW_KEY, out List<CashFlow> cashFlowList))
                cashFlowList.Add(cashFlow);
            else
                cashFlowList = new() { cashFlow };

            _memoryCache.Set(CASHFLOW_KEY, cashFlowList);
        }

        public List<CashFlow> GetAllOfToday()
        {
            List<CashFlow> cashFlowList = _memoryCache.Get<List<CashFlow>>(CASHFLOW_KEY);
            cashFlowList ??= new List<CashFlow>();

            return cashFlowList.Where(x => x.CreatedDate >= DateTime.Now.Date && x.CreatedDate <= DateTime.Now).ToList();
        }

        public decimal GetSumOfCreditsToday()
        {
            return GetAllOfToday().Where(x => x.CashFlowTypeId == CashFlowTypeStatic.Credit.Id).Sum(x => x.Value);
        }

        public decimal GetSumOfDebitsToday()
        {
            return GetAllOfToday().Where(x => x.CashFlowTypeId == CashFlowTypeStatic.Debit.Id).Sum(x => x.Value);
        }
    }
}
