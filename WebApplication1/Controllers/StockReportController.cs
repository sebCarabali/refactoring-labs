using Application.UserCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockReportController : ControllerBase
    {
        private readonly StockReportUseCase _stockReportUseCase;

        public StockReportController(StockReportUseCase useCase)
        {
            this._stockReportUseCase = useCase;   
        }

        [HttpGet]
        public async Task<IActionResult> GetStockReport()
        {
            try
            {
                var repot = await _stockReportUseCase.GetStockReportAsync();
                return Ok(repot);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
