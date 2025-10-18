using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Sales
{
    public class SalesUnitOfWork : IUnitOfWork
    {
        private readonly SalesDbContext _salesDbContext;
        public SalesUnitOfWork(SalesDbContext salesDbContext)
        {
            _salesDbContext = salesDbContext;
        }
        public void Dispose()
        {
            _salesDbContext.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _salesDbContext.SaveChangesAsync();
        }
    }
}
