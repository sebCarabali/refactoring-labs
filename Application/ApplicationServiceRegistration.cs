using Application.UserCases;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<UserRegistrationUseCase>();
            services.AddScoped<ApplyDiscountUseCase>();
            services.AddScoped <TransferInventoryUseCase>();
            services.AddScoped<StockReportUseCase>();
            return services;
        }
    }
}
