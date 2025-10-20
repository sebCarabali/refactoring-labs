using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class StockReportDTO
    {
        public string? CategoryName { get; set; }
        public int CategoryTotalStock { get; set; }
        public string? BestProduct { get; set; }
        public int BestProductStock { get; set; }
        public string? PrincipalWarehose { get; set; }
    }
}
