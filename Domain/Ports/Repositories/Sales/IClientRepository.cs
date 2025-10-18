
using Domain.Models.Sales;

namespace Domain.Ports.Repositories.Sales
{
    public interface IClientRepository
    {
        Task<Client?> GetByIdAsync(int clientId);
    }
}
