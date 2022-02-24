using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SanctionList.Server.Application.Handlers.FuzzyNameFinder;

namespace SanctionList.Server.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<LevenshteinByPartition>();

        return services;
    }
}