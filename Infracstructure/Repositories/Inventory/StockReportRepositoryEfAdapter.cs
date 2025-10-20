using Domain;
using Domain.Ports.Repositories.Inventory;
using Infrastructure.Persistence.Sales;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Inventory
{
    public class StockReportRepositoryEfAdapter : IStockReportRepository
    {
        private readonly SalesDbContext _salesDbContext;

        public StockReportRepositoryEfAdapter(SalesDbContext salesDbContext)
        {
            _salesDbContext = salesDbContext;
        }

        public async Task<IEnumerable<StockReportDTO>> GetStockReportAsync()
        {
            var reportQuery = _salesDbContext.Categories
    .AsNoTracking()
    .Select(cat => new
    {
        // 1. Obtenemos la categoría
        CategoryName = cat.Name,

        // 2. Obtenemos todos los items de inventario de esta categoría
        CategoryInventoryItems = cat.Products.SelectMany(p => p.InventoryItems),

        // 3. ENCONTRAMOS EL PRODUCTO ESTRELLA
        //    Calculamos el stock total POR producto y ordenamos para encontrar el TOP 1
        BestProductInfo = cat.Products
            .Select(p => new
            {
                // Obtenemos los datos que necesitamos del producto
                ProductId = p.ProductId,
                ProductName = p.Name,
                // Esta es la lógica que faltaba: Sumar el stock POR producto
                ProductTotalStock = p.InventoryItems.Sum(inv => (int?)inv.Quantity) ?? 0
            })
            .OrderByDescending(p => p.ProductTotalStock)
            .FirstOrDefault() // Esto es el "prod_estrella" del SP
    })
    // 4. Proyectamos al DTO final
    .Select(intermediate => new StockReportDTO
    {
        CategoryName = intermediate.CategoryName,

        // APPLY 1: Sumamos el stock total de la categoría
        CategoryTotalStock = intermediate.CategoryInventoryItems.Sum(inv => (int?)inv.Quantity) ?? 0,

        // APPLY 2: Extraemos los datos del producto estrella (que ya calculamos)
        BestProduct = intermediate.BestProductInfo.ProductName, // Maneja NULL si no hay productos
        BestProductStock = intermediate.BestProductInfo.ProductTotalStock,

        // APPLY 3: Buscamos el almacén principal
        // Esta es la única subconsulta interna que necesitamos,
        // pero sigue siendo parte de la misma expresión IQueryable.
        PrincipalWarehose = intermediate.BestProductInfo == null ? null :
            _salesDbContext.InventoryItems // Nótese: 'Stock' es 'Quantity' en tu DTO
                .Where(inv => inv.ProductId == intermediate.BestProductInfo.ProductId)
                .OrderByDescending(inv => inv.Quantity)
                .Select(inv => inv.Warehouse.Name)
                .FirstOrDefault()
    })
    .OrderByDescending(r => r.CategoryTotalStock);

            // Finalmente, ejecutamos la consulta (1 solo viaje a la BD)
            var report = await reportQuery.ToListAsync();
            return report;
        }
    }
}
