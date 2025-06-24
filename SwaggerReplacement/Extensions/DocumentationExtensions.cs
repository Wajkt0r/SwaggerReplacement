using Microsoft.OpenApi;
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
        // In .NET 9, OpenAPI transformers were introduced to handle things like Bearer auth automatically,
        // but they currently don’t apply the security schemes correctly in the generated v1.json.
        // This issue also affects OpenAPI-UI. Likely needs a future update from the OpenAPI library.
        //endpoints.MapOpenApi(); 

        return endpoints;
    }
}
