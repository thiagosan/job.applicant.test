using BestHB.Domain.Entities;
using BestHB.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestHB.Domain.Repositories;

public interface IRepository
{
    Task<int> Add(Order order);

    Task<List<Order>> Get(QueryOrders queryOrders);

    Task<InstrumentInfo> Get(string symbol);
}
