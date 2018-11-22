using MetasiteTask.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetasiteTask.Repositories.Contracts
{
    public interface IOperationRepository
    {
        Task<int> GetOperationsCountAsync(DateTime startDate, DateTime endDate, OperationType type);

        Task<List<string>> GetTopSmsMsisdnsAsync(DateTime startDate, DateTime endDate);

        Task<List<string>> GetTopCallMsisdnsAsync(DateTime startDate, DateTime endDate);
    }
}
