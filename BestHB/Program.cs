using BestHB.Domain.Repositories;
using BestHB.Domain.Service;
using BestHB.Domain.Services;
using BestHB.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IRepository, InstrumentInfoRepository>();
builder.Services.AddTransient<IRepository, OrderRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
