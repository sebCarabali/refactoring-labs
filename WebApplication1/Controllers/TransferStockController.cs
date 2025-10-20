using Application.UserCases;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto.Request;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferStockControlle : ControllerBase
    {
        private readonly TransferInventoryUseCase _useCase;

        public TransferStockControlle(TransferInventoryUseCase transferInventoryUseCase)
        {
            _useCase = transferInventoryUseCase;
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> TransferStocks([FromBody] TransferStockRequest request)
        {
            try
            {
                await _useCase.TransferStock(request.ProductID, request.FromWarehouseId, request.ToWarehouseId, request.Quantity);
                return Ok(new { Message = $"Se tranfieron {request.Quantity} unidades correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
