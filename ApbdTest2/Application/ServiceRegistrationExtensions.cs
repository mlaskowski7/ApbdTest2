using ApbdTest2.Application.Mappers;
using ApbdTest2.Application.Mappers.Impl;
using ApbdTest2.Application.Services;
using ApbdTest2.Application.Services.Impl;

namespace ApbdTest2.Application;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        return services.AddMappers().AddServices();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddScoped<ICustomerService, CustomerService>().AddScoped<DateTimeProvider>();
    }

    private static IServiceCollection AddMappers(this IServiceCollection services)
    {
        return services.AddScoped<ITicketMapper, TicketMapper>()
            .AddScoped<IConcertMapper, ConcertMapper>()
            .AddScoped<IPurchasedTicketMapper, PurchasedTicketMapper>()
            .AddScoped<ICustomerMapper, CustomerMapper>();
    }
}