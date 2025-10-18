using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Sales.Discount
{
    internal class VipDiscountStrategy : IDiscountStrategy
    {
        public decimal GetDiscountPercentage(Product product)
        {
            return 0.20m; // 20% discount for VIP customers
        }
    }
}
