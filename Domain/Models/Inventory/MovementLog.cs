using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Inventory
{
    public class MovementLog
    {
        public int MovementId { get; set; }
        public int ProductId { get; set; }
        public int FromWarehouseId { get; set; }
        public int ToWarehouseId { get; set; }
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }

        private MovementLog(int productId, int fromWarehouseId, int toWarehouseId, int quantity)
        {
            ProductId = productId;
            FromWarehouseId = fromWarehouseId;
            ToWarehouseId = toWarehouseId;
            Quantity = quantity;
            MovementDate = DateTime.UtcNow;
        }

        public static MovementLog Create(int productId, int fromWarehouseId, int toWarehouseId, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("La cantidad de movimiento debe ser positiva.");
            }
            return new MovementLog(productId, fromWarehouseId, toWarehouseId, quantity);
        }
    }
}
