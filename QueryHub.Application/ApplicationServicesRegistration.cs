using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace QueryHub.Application;

public static class ApplicationServicesRegistration
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        #region Automapper

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        #endregion
    }
}