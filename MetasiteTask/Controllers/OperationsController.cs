using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetasiteTask.Models.Enums;
using MetasiteTask.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MetasiteTask.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OperationsController : Controller
    {
        private readonly IOperationRepository operationRepository;

        public OperationsController(IOperationRepository operationRepository)
        {
            this.operationRepository = operationRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetSmsCount(DateTime startDate, DateTime endDate)
        {
            var smsCount = await operationRepository.GetOperationsCountAsync(startDate, endDate, OperationType.sms);
            return Ok(new
            {
                Count = smsCount
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetCallCount(DateTime startDate, DateTime endDate)
        {
            var callCount = await operationRepository.GetOperationsCountAsync(startDate, endDate, OperationType.call);
            return Ok(new
            {
                Count = callCount
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetTopSmsMsisdns(DateTime startDate, DateTime endDate)
        {
            var msisdns = await operationRepository.GetTopSmsMsisdnsAsync(startDate, endDate);
            return Ok(new
            {
                Msisdns = msisdns
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetTopCallMsisdns(DateTime startDate, DateTime endDate)
        {
            var msisdns = await operationRepository.GetTopCallMsisdnsAsync(startDate, endDate);
            return Ok(new
            {
                Msisdns = msisdns
            });
        }
    }
}
