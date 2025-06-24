using Microsoft.OpenApi;
using Scalar.AspNetCore;
using SwaggerReplacement.Transformers;

namespace SwaggerReplacement.Extensions;

public static class DocumentationExtensions
{
    public static IServiceCollection AddApiDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddOpenApi(options =>
        {
            options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
            options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
        });

        return services;
    }

    public static IEndpointRouteBuilder UseApiDocumentation(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapOpenApi();

        endpoints.MapScalarApiReference(options =>
        {
            options
                .WithTitle("Swagger Replacement – Scalar")
                .WithTheme(ScalarTheme.BluePlanet)
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);      
        });

        return endpoints;
    }
}
