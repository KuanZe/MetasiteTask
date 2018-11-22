using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetasiteTask.Repositories.Contracts
{
    public interface IBaseRepository
    {
        Task InitializeDatabase();

        Task GenerateDemoData();
    }
}
