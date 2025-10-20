using Domain.Ports;
using Domain.Ports.Repositories;
using Domain.Ports.Repositories.Inventory;
using Domain.Ports.Repositories.Sales;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Sales;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Inventory;
using Infrastructure.Repositories.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepositoriEfAdapter>();
            services.AddScoped<IProductRepository, ProductRepositoryEfAdapter>();
            services.AddScoped<IClientRepository, ClientRepositoryEfAdapter>();
            services.AddScoped<IMovementLogRepository, MovementLogRepositoryEfAdapter>();
            services.AddScoped<IInventoryRepository, InventoryRepositoryEfAdapter>();
            services.AddScoped<IStockReportRepository, StockReportRepositoryEfAdapter>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SalesUnitOfWork>();
            services.AddDbContext<SalesDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("SalesDatabase");
                options.UseSqlServer(connectionString);
            });
            services.AddDbContext<SecurityDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("SecurityDatabase");
                options.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}
