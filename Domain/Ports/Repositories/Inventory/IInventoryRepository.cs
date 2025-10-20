using Domain.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports.Repositories.Inventory
{
    public interface IInventoryRepository
    {
        Task<InventoryItem> FindByProductAndWarehouseAsync(int productId, int warehouseId);
    }
}
