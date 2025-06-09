using ApbdTest2.Infrastructure.Database;
using ApbdTest2.Infrastructure.Persistance;
using ApbdTest2.Infrastructure.Repositories;
using ApbdTest2.Infrastructure.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace ApbdTest2.Infrastructure;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<ConcertsDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentException("Default connection string must be set"));
        }).AddRepositories().AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<ICustomerRepository, CustomerRepository>().AddScoped<IPurchasedTicketRepository, PurchasedTicketRepository>().AddScoped<IConcertRepository, ConcertRepository>();
    }
}