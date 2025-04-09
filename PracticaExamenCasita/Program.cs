using Microsoft.EntityFrameworkCore;
using PracticaExamenCasita.Data;
using PracticaExamenCasita.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string connection = builder.Configuration.GetConnectionString("DataBaseCubos");
builder.Services.AddTransient<RepositoryCubos>();
builder.Services.AddDbContext<CubosContext>(options =>
    options.UseSqlServer(connection));
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseHttpsRedirection();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "API Repasito");
    options.RoutePrefix = "";
});
app.UseAuthorization();
app.MapControllers();
app.Run();

