

using Domain.Models.Inventory;
using Domain.Ports.Repositories.Inventory;
using Infrastructure.Persistence.Sales;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Inventory
{
    public class InventoryRepositoryEfAdapter : IInventoryRepository
    {
        private readonly SalesDbContext _salesDbContext;

        public InventoryRepositoryEfAdapter(SalesDbContext salesDbContext)
        {
            _salesDbContext = salesDbContext;
        }

        public async Task<InventoryItem> FindByProductAndWarehouseAsync(int productId, int warehouseId)
        {
            return await _salesDbContext.InventoryItems
                .FirstOrDefaultAsync(i => i.ProductId == productId && i.WarehouseId == warehouseId);
        }
    }
}
