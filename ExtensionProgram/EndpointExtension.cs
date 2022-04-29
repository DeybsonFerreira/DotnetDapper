using Microsoft.AspNetCore.Builder;

public static class EndpointExtension
{
    public static void AddCustomEndpoints(this WebApplication app)
    {
        MapPersonEndpoint.AddPersonEndpoint(app);
    }
}