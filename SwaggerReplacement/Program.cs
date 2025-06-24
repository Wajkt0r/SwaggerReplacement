using JakubKozera.OpenApiUi;
using SwaggerReplacement.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApiDocumentation();
builder.Services.AddAuthAndCors();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// In .NET 9, OpenAPI transformers were introduced to handle things like Bearer auth automatically,
// but they currently don’t apply the security schemes correctly in the generated v1.json.
// This issue also affects Swagger-UI. Likely needs a future update from the OpenAPI library.
//app.MapOpenApi();

app.UseStaticFiles();

app.UseOpenApiUi(options =>
{
    options.OpenApiSpecPath = "openapi/v1.json";
});

app.Run();
