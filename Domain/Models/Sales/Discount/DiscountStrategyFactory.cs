using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Sales.Discount
{
    public class DiscountStrategyFactory
    {
        protected DiscountStrategyFactory() { }
        public static IDiscountStrategy GetDiscountStrategy(ClientType clientType)
        {
            return clientType switch
            {
                ClientType.VIP => new VipDiscountStrategy(),
                ClientType.Member => new MemberDiscountStrategy(),
                ClientType.Regular => new RegularDiscountStrategy(),
                _ => throw new ArgumentException("Invalid client type"),
            };
        }
    }
}
