using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;

namespace FiftyNine.ModularMonolith.OrderManagement.Module.Tests.Controllers;

public class OrdersControllerTests
{
    [Fact]
    public async Task Returns_order_if_passed_correct_id()
    {
        var application = new WebApplicationFactory<Program>();
        var client = application.CreateClient();

        var response = await client.GetAsync("/api/orders/1");

        response.EnsureSuccessStatusCode();

        dynamic order = JObject.Parse(await response.Content.ReadAsStringAsync());

        Assert.Equal(1, (int)order.id);
        Assert.Equal(DateTime.Now.ToString("yyyy-MM-dd HH:mm"), (string)order.orderDate);
        Assert.NotNull(order.orderedBy);
        Assert.Equal(1, (int)order.orderedBy.id);
        Assert.Equal("John", (string)order.orderedBy.firstName);
        Assert.Equal("Doe", (string)order.orderedBy.lastName);
    }
}
