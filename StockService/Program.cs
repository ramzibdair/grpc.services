using OrderService.Domain.IRepositories;
using OrderService.Infrastructure.MongoDB;
using StockService.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IStockRepositry, StockRepositry>();
builder.Services.AddScoped<IStockContext, StockContext>();

builder.Services.Configure<StockDatabaseSettings>(
    builder.Configuration.GetSection("StockDatabase"));

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
