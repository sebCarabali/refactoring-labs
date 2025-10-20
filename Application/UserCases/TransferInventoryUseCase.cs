using Domain.Ports;
using Domain.Ports.Repositories.Inventory;
using Domain.Services;
using Infrastructure.Persistence.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserCases
{
    public class TransferInventoryUseCase
    {
        private readonly TransferStockService _transferStockService;
        private readonly SalesUnitOfWork _salesUnitOfWork;

        public TransferInventoryUseCase(TransferStockService transferStockService, SalesUnitOfWork salesUnitOfWork)
        {
            _transferStockService = transferStockService;
            _salesUnitOfWork = salesUnitOfWork;
        }

        public async Task TransferStock(int productId, int fromWarehoseId, int toWarehoseId, int quantity)
        {
            await _transferStockService.TransferStockAsync(productId, fromWarehoseId, toWarehoseId, quantity);
            await _salesUnitOfWork.SaveChangesAsync();
        }
    }
}
