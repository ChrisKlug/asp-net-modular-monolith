namespace FiftyNine.ModularMonolith.OrderManagement.Module.Entities;

public class Order
{
    public int Id { get; init; }
    public DateTime OrderDate { get; init; }
    public int OrderedById { get; init; }

    internal static Order? Create(int id, DateTime orderDate)
        => new Order
        {
            Id = id,
            OrderDate = orderDate,
            OrderedById = 1
        };
}
