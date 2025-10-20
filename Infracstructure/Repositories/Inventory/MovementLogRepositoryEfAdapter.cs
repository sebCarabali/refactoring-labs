using Domain.Models.Inventory;
using Domain.Ports.Repositories.Inventory;
using Infrastructure.Persistence.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Inventory
{
    public class MovementLogRepositoryEfAdapter : IMovementLogRepository
    {
        private readonly SalesDbContext _salesDbContext;

        public MovementLogRepositoryEfAdapter(SalesDbContext salesDbContext)
        {
            _salesDbContext = salesDbContext;
        }

        public async Task AddMovementLogAsync(MovementLog movementLog)
        {
            await _salesDbContext.Movements.AddAsync(movementLog);
        }
    }
}
