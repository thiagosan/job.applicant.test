using BestHB.Domain.Commands;
using BestHB.Domain.Queries;
using BestHB.Domain.Repositories;
using BestHB.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestHB.Controllers;

[Route("api/orders")]
public class OrdersController(OrderService orderService, IRepository orderRepository) : Controller
{
    [HttpPost]
    [Route("add")]
    public IActionResult Add([FromBody] CreateOrderCommand command)
    {
        try
        {
            var orderId = orderService.Create(command);
            return Ok(orderId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("delete")]
    public IActionResult Delete([FromBody] DeleteOrderCommand command)
    {
        try
        {
            var status = orderService.Delete(command);
            return Ok(status);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("get")]
    public async Task<IActionResult> Get([FromBody] QueryOrders queryOrders)
    {
        try
        {
            var orders = await orderRepository.Get(queryOrders);
            return Ok(orders);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("csv")]
    public async Task<IActionResult> GetAsCSV([FromBody] QueryOrders queryOrders)
    {
        try
        {
            return Ok(await orderService.AsCSV(queryOrders));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}