using Domain.Exceptions;
using Domain.Models.Sales;

namespace Domain.Models.Inventory
{
    public class InventoryItem
    {
        public int InventoryItemId { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public int WarehouseId { get; private set; }
        public Warehouse Warehouse { get; private set; }
        public int Quantity { get; private set; }
        public byte[]? Version { get; private set; }

        private InventoryItem(int productId, int warehouseId, int quantity)
        {
            ProductId = productId;
            WarehouseId = warehouseId;
            Quantity = quantity;
        }
        public static InventoryItem Create(int productId, int warehouseId, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("La cantidad no puede ser negativa.");
            }
            return new InventoryItem(productId, warehouseId, quantity);
        }
        public void IncrementStock(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("La cantidad a agregar debe ser positiva.");
            }
            Quantity += amount;
        }
        public void DecrementStock(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("La cantidad a remover debe ser positiva.");
            }
            if (amount > Quantity)
            {
                throw new BusinessRuleValidationException("No hay suficiente stock para remover la cantidad solicitada.");
            }
            Quantity -= amount;
        }
    }
}
