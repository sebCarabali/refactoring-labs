using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DomainServiceRegistration
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<UserRegistrationService>();
            services.AddScoped<DiscountService>();
            services.AddScoped<TransferStockService>();
            services.AddScoped<StockReportService>();
            return services;
        }
    }
}
