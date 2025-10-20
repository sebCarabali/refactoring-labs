using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports.Repositories.Inventory
{
    public interface IStockReportRepository
    {
        Task<IEnumerable<StockReportDTO>> GetStockReportAsync();
    }
}
