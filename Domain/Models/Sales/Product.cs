using Domain.Models.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Sales
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        private readonly List<InventoryItem> _inventoryItems = new();
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public decimal? DiscountPrice { get; set; }

        public IReadOnlyCollection<InventoryItem> InventoryItems => _inventoryItems.AsReadOnly();

        public void SetDiscountPrice(ClientType clientType)
        {
            this.DiscountPrice = PriceCalculator.CalculateFinalPrice(this, clientType);
        }
    }
}
