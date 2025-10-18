using Domain.Models.Sales;
using Domain.Ports.Repositories.Sales;
using Infrastructure.Persistence.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Sales
{
    public class ProductRepositoryEfAdapter : IProductRepository
    {
        private readonly SalesDbContext _dbContext;

        public ProductRepositoryEfAdapter(SalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await _dbContext.Products.FindAsync(productId);
        }
    }
}
