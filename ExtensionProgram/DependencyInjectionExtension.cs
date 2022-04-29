using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtension
{
    public static WebApplicationBuilder AddCustomDependence(this WebApplicationBuilder builder)
    {
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        AddInterfaces(connectionString, builder);
        return builder;
    }

    private static void AddInterfaces(string connectionString, WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IPersonRepository>(sp => new PersonRepository(connectionString));
    }
}