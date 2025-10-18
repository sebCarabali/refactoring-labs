using Domain.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports.Repositories.Sales
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int productId);
    }
}
