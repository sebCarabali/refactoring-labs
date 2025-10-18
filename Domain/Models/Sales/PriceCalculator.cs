using Domain.Models.Sales.Discount;

namespace Domain.Models.Sales
{
    public class PriceCalculator
    {
        protected PriceCalculator() { }
        public static decimal CalculateFinalPrice(Product product, ClientType clientType)
        {
            var discountStrategy = DiscountStrategyFactory.GetDiscountStrategy(clientType);
            var discountPercentage = discountStrategy.GetDiscountPercentage(product);
            var discountAmount = product.Price * discountPercentage;
            return product.Price - discountAmount;
        }
    }
}
