using MetasiteTask.Models;
using MetasiteTask.Models.Enums;
using MetasiteTask.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetasiteTask.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly DataContext dbContext;

        public OperationRepository(DataContext context)
        {
            dbContext = context;
        }

        public async Task<int> GetOperationsCountAsync(DateTime startDate, DateTime endDate, OperationType type)
        {
            return await dbContext.Operations.CountAsync(x => startDate <= x.Date && x.Date <= endDate && x.Type == type.ToString());
        }

        public async Task<List<string>> GetTopSmsMsisdnsAsync(DateTime startDate, DateTime endDate)
        {
            return await dbContext.Operations.Where(x => x.Type == OperationType.sms.ToString() && startDate <= x.Date && x.Date <= endDate)
                .GroupBy(y => y.Msisdn).OrderByDescending(z => z.Count()).Take(5).Select(v => v.Key).ToListAsync();
        }

        public async Task<List<string>> GetTopCallMsisdnsAsync(DateTime startDate, DateTime endDate)
        {
            return await dbContext.Operations.Where(x => x.Type == OperationType.call.ToString() && startDate <= x.Date && x.Date <= endDate)
                .OrderByDescending(z => z.Duration).Take(5).Select(v => v.Msisdn).ToListAsync();
        }
    }
}
