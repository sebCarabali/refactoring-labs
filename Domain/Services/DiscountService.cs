using Domain.Exceptions;
using Domain.Ports;
using Domain.Ports.Repositories.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class DiscountService
    {
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DiscountService(IProductRepository productRepository, IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task ApplyDiscountAsync(int productId, int clientId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            var client = await _clientRepository.GetByIdAsync(clientId);
            if (product == null )
            {
                throw new BusinessRuleValidationException("Producto no encontrado.");
            }

            if (client == null)
            {
                throw new BusinessRuleValidationException("Cliente no encontrado.");
            }

            product.SetDiscountPrice(client.Type);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
