using FiftyNine.ModularMonolith.OrderManagement.Module.Entities;

namespace FiftyNine.ModularMonolith.OrderManagement.Module.Data;

public interface IOrders
{
    Task<Order?> WithId(int id);
}

public class Orders : IOrders
{
    public Task<Order?> WithId(int id)
    {
        if (id != 1)
        {
            return Task.FromResult<Order?>(null);
        }

        return Task.FromResult<Order?>(Order.Create(id, DateTime.Now));
    }
}
