using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Sales.Discount
{
    internal class RegularDiscountStrategy : IDiscountStrategy
    {
        public decimal GetDiscountPercentage(Product product)
        {
            return 0.0m; // No discount for regular customers
        }
    }
}
