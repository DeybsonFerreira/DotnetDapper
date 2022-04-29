using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.AddCustomDependence();
builder.AddSwaggerBuilder();

var app = builder.Build();
app.AddCustomEndpoints();
app.UseSwaggerExtension();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();