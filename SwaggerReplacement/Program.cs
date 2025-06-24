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

app.MapOpenApi();
app.UseOpenApiUi(options =>
{
    options.OpenApiSpecPath = "openapi/v1.json";
});

app.Run();
