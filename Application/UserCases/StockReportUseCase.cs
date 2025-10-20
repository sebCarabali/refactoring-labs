using Domain;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserCases
{
    public class StockReportUseCase
    {
        private readonly StockReportService _stockReportService;

        public StockReportUseCase(StockReportService stockReportService)
        {
            _stockReportService = stockReportService;
        }

        public async Task<IEnumerable<StockReportDTO>> GetStockReportAsync()
        {
            return await _stockReportService.GetAllStockReportsAsync();
        }
    }
}
