using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Sales.Discount
{
    public interface IDiscountStrategy
    {
        public decimal GetDiscountPercentage(Product product);
    }
}
