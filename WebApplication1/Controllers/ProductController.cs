using Application.UserCases;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ApplyDiscountUseCase _applyDiscountUseCase;
        public ProductController(ApplyDiscountUseCase applyDiscountUseCase)
        {
            _applyDiscountUseCase = applyDiscountUseCase;
        }

        [HttpPut("discount")]
        public async Task<IActionResult> ApplyDiscountToProduct([FromBody] ApplyDiscountRequest request)
        {
            try
            {
                await _applyDiscountUseCase.ApplyDiscountAsync(request.ProductId, request.ClientId);
                return Ok(new { Message = "Disccount succesfully apply" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
