using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

public static class SwaggerExtension
{
    public static WebApplicationBuilder AddSwaggerBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Description = "Docs for my API", Version = "v1" });
        });
        return builder;
    }

    public static WebApplication UseSwaggerExtension(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
        return app;
    }
}