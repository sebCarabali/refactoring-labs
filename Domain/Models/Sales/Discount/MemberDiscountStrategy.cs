using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Sales.Discount
{
    internal class MemberDiscountStrategy : IDiscountStrategy
    {
        private const string ElectronicCategory = "Electronica";
        public decimal GetDiscountPercentage(Product product)
        {
            if (product.Category.Name == ElectronicCategory)
            {
                return 0.10m; // 10% en electrónica
            }
            else
            {
                return 0.05m; // 5% en el resto
            }
        }
    }
}
