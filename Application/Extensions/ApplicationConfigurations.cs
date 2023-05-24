using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ApplicationConfigurations
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assembly);
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
    }
}