using CashFlowManagement.Crosscutting.Dtos;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CashFlowManagement.Application.Contracts
{
    public interface ICashFlowApplicationService
    {
        Task<ValidationResult> Add(CashFlowFormDTO dto);
        Task<List<CashFlowDTO>> GetAllOfToday();
        Task<CashFlowReportTodayDTO> GetConsolidatedBalanceReport();
    }
}
