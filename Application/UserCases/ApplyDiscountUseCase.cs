using Domain.Ports;
using Domain.Ports.Repositories.Sales;
using Domain.Services;
using Infrastructure.Persistence.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserCases
{
    public class ApplyDiscountUseCase
    {
        private readonly DiscountService _discountService;
        private readonly SalesUnitOfWork _unitOfWork;
        public ApplyDiscountUseCase(DiscountService discountService, SalesUnitOfWork unitOfWork)
        {
            _discountService = discountService;
            _unitOfWork = unitOfWork;
        }

        public async Task ApplyDiscountAsync(int productId, int clientId)
        {
            await _discountService.ApplyDiscountAsync(productId, clientId);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
