using Domain.Ports.Repositories.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class StockReportService
    {
        private readonly IStockReportRepository _stockReportRepository;

        public StockReportService(IStockReportRepository stockReportRepository)
        {
            _stockReportRepository = stockReportRepository;
        }

        public async Task<IEnumerable<StockReportDTO>> GetAllStockReportsAsync()
        {
            return await _stockReportRepository.GetStockReportAsync();
        }
    }
}
