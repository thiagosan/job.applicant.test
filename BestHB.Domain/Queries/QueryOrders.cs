using BestHB.Domain.Commands;

namespace BestHB.Domain.Queries;

public class QueryOrders
{
    public int UserId { get; set; }
    public string Instrument { get; set; }
    public OrderType? Type { get; set; }
    public OrderSide? Side { get; set; }
}
