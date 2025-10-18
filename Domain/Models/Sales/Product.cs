using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Sales
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public required string Categoy { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }

        public void SetDiscountPrice(ClientType clientType)
        {
            this.DiscountPrice = PriceCalculator.CalculateFinalPrice(this, clientType);
        }
    }
}
