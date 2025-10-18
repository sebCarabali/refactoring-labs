using Domain.Models.Sales;
using Domain.Ports.Repositories.Sales;
using Infrastructure.Persistence.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Sales
{
    public class ClientRepositoryEfAdapter : IClientRepository
    {
        private readonly SalesDbContext _dbContext;
        public ClientRepositoryEfAdapter(SalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Client?> GetByIdAsync(int clientId)
        {
            return await _dbContext.Clients.FindAsync(clientId);
        }
    }
}
