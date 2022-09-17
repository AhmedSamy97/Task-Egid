using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StocksApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
// Add services to the container.

builder.Services.AddSingleton<StockPriceHub>();
builder.Services.AddCors();
builder.Services.AddControllers();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials());
app.UseAuthorization();

app.MapControllers();
app.MapHub<StockPriceHub>("/StockPrice");


app.Run();
