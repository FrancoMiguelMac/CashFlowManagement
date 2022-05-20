using CashFlowManagement.Application.Contracts;
using CashFlowManagement.Application.Extensions;
using CashFlowManagement.Crosscutting.Dtos;
using CashFlowManagement.Domain.Contracts.Repositories;
using CashFlowManagement.Domain.Entities;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CashFlowManagement.Application.Implementations
{
    public class CashFlowApplicationService : ICashFlowApplicationService
    {
        private readonly ICashFlowRepository _cashFlowRepository;

        public CashFlowApplicationService(ICashFlowRepository cashFlowRepository)
        {
            _cashFlowRepository = cashFlowRepository;
        }

        public async Task<ValidationResult> Add(CashFlowFormDTO dto)
        {
            CashFlow cashFlow = new(dto.Description, dto.Value, dto.CashFlowTypeId);

            if (cashFlow.IsValid())
                _cashFlowRepository.Add(cashFlow);

            return await Task.FromResult(cashFlow.ValidationResult);
        }

        public async Task<List<CashFlowDTO>> GetAllOfToday()
        {
            return await Task.FromResult(_cashFlowRepository.GetAllOfToday().ConvertToDTO());
        }

        public async Task<CashFlowReportTodayDTO> GetConsolidatedBalanceReport()
        {
            decimal totalCredits = _cashFlowRepository.GetSumOfCreditsToday();
            decimal totalDebits = _cashFlowRepository.GetSumOfDebitsToday();

            return await Task.FromResult(new CashFlowReportTodayDTO
            {
                TotalCredits = totalCredits,
                TotalDebts = totalDebits,
                Balance = totalCredits + totalDebits
            });
        }
    }
}
