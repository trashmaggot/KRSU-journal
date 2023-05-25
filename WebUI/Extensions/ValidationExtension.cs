using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace WebUI.Extensions;

public static class ValidationExtension
{
    public static void ConfigureValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}