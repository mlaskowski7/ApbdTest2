namespace ApbdTest2.Application;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        return services.AddMappers().AddServices();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection AddMappers(this IServiceCollection services)
    {
        return services;
    }
}