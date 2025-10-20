using Domain.Models.Inventory;
using Domain.Ports;
using Domain.Ports.Repositories.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class TransferStockService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMovementLogRepository _movementLogRepository;
    
        public TransferStockService(IInventoryRepository inventoryRepository, IMovementLogRepository movementLogRepository)
        {
            _inventoryRepository = inventoryRepository;
            _movementLogRepository = movementLogRepository;
        }

        public async Task TransferStockAsync(int productId, int fromWarehouseId, int toWarehouseId, int quantity)
        {
            if (fromWarehouseId == toWarehouseId)
            {
                throw new ArgumentException("El almacén de origen y destino no pueden ser el mismo.");
            }

            if (quantity <= 0)
            {
                throw new ArgumentException("La cantidad a transferir debe ser positiva.");
            }
            var fromInventoryItem = await _inventoryRepository.FindByProductAndWarehouseAsync(productId, fromWarehouseId);
            if (fromInventoryItem == null)
            {
                throw new InvalidOperationException("El producto no existe en el almacén de origen.");
            }
            var toInventoryItem = await _inventoryRepository.FindByProductAndWarehouseAsync(productId, toWarehouseId);
            if (toInventoryItem == null)
            {
                throw new InvalidOperationException("El producto no existe en el almacén de destino.");
            }
            fromInventoryItem.DecrementStock(quantity);
            toInventoryItem.IncrementStock(quantity);

            var movementLog = MovementLog.Create(productId, fromWarehouseId, toWarehouseId, quantity);
            await _movementLogRepository.AddMovementLogAsync(movementLog);
        }
    }
}
