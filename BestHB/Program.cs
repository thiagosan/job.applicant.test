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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
