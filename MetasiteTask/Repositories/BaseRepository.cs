using MetasiteTask.Models;
using MetasiteTask.Models.Enums;
using MetasiteTask.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetasiteTask.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly DataContext dbContext;

        public BaseRepository(DataContext context)
        {
            dbContext = context;
        }

        public async Task InitializeDatabase()
        {
            await dbContext.Database.EnsureCreatedAsync();
            dbContext.Operations.RemoveRange(dbContext.Operations.ToList());
        }

        public async Task GenerateDemoData()
        {
            if (dbContext.Operations.Count() != 0)
                return;

            var operations = new List<Operation>();
            Random rng = new Random();

            for(int i = 0; i < 500; i++)
            {
                operations.Add(new Operation
                {
                    Date = new DateTime(2018, 10, rng.Next(1, 31)),
                    Msisdn = "370623000" + rng.Next(10, 99),
                    Duration = 0,
                    Type = OperationType.sms.ToString()
                });
                operations.Add(new Operation
                {
                    Date = new DateTime(2018, 10, rng.Next(1, 31)),
                    Msisdn = "370623000" + rng.Next(10, 99),
                    Duration = rng.Next(1, 1000),
                    Type = OperationType.call.ToString()
                });
            }

            await dbContext.Operations.AddRangeAsync(operations);
            await dbContext.SaveChangesAsync();
        }
    }
}
