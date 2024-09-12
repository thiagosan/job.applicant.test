using BestHB.Domain.Commands;
using BestHB.Domain.Entities;
using BestHB.Domain.Repositories;
using BestHB.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace BestHB.Tests;

[TestClass]
public class OrdersTest
{
    [TestMethod]
    public void invalid_lot_size_on_create_order_test()
    {
        // Arrange
        CreateOrderCommand command = new()
        {
            Price = 10,
            Quantity = 40,
            Side = OrderSide.Sell,
            Symbol = "PETR4",
            Type = OrderType.Market,
            UserId = 123
        };

        InstrumentInfo instrumentInfo = new()
        {
            Type = InstrumentType.Stock,
            Symbol = "PETR4",
            Description = "PETROBRAS",
            Exchange = "BOVESPA",
            ISIN = "123456",
            LotStep = 100,
            MaxLot = 100000,
            MinLot = 100
        };

        IRepository instrumentInfoRepositoryMock = Substitute.For<IRepository>();
        instrumentInfoRepositoryMock.Get(Arg.Any<string>()).Returns(instrumentInfo);

        IRepository orderRepositoryMock = Substitute.For<IRepository>();

        // Act
        var orderService = new OrderService(orderRepositoryMock, instrumentInfoRepositoryMock);

        // Assert
        var exception = Assert.ThrowsException<Exception>(() => orderService.Create(command));

        Assert.AreEqual("Quantidade inválida.", exception.Message);
    }
}
