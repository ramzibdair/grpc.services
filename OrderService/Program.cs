using Microsoft.Extensions.Configuration;
using OrderService.Domain.IRepositories;
using OrderService.grpcServices;
using OrderService.Infrastructure.MongoDB;
using OrderService.Options;
using StockService.Protos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGrpcClient<StockProtoService.StockProtoServiceClient>(opt =>
            opt.Address = new Uri(builder.Configuration.GetValue<string>("StockGprcServerSetting:Address")));
builder.Services.AddScoped<IOrderRepositry, OrderRepositry>();
builder.Services.AddScoped<IOrderContext, OrderContext>();
builder.Services.AddScoped<StockServiceClient>();

builder.Services.Configure<OrderDatabaseSettings>(
    builder.Configuration.GetSection("OrderDatabase"));

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
