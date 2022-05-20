using CashFlowManagement.Application.Contracts;
using CashFlowManagement.Crosscutting.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CashFlowManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CashFlowController : ApiController
    {
        private readonly ICashFlowApplicationService _cashFlowApplicationService;

        public CashFlowController(ICashFlowApplicationService cashFlowApplicationService)
        {
            _cashFlowApplicationService = cashFlowApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CashFlowFormDTO dto)
        {
            return CustomResponse(await _cashFlowApplicationService.Add(dto));
        }

        [HttpGet("GetAllOfToday")]
        public async Task<List<CashFlowDTO>> GetAllOfToday()
        {
            return await _cashFlowApplicationService.GetAllOfToday();
        }

        [HttpGet("GetConsolidatedBalanceReport")]
        public async Task<CashFlowReportTodayDTO> GetConsolidatedBalanceReport()
        {
            return await _cashFlowApplicationService.GetConsolidatedBalanceReport();
        }
    }
}
