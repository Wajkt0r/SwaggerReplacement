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

app.UseApiDocumentation();

app.Run();
