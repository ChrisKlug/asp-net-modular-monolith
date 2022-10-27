using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;

namespace FiftyNine.ModularMonolith.Api.Tests.Orders;

public class OrdersTests
{
    [Fact]
    public async Task Returns_order_if_passed_correct_id()
    {
        var application = new WebApplicationFactory<ApiProgram>();
        var client = application.CreateClient();

        var response = await client.GetAsync("/api/orders/1");

        response.EnsureSuccessStatusCode();

        dynamic order = JObject.Parse(await response.Content.ReadAsStringAsync());

        Assert.Equal(1, (int)order.id);
        Assert.Equal(DateTime.Now.ToString("yyyy-MM-dd HH:mm"), (string)order.orderDate);
        Assert.NotNull(order.orderedBy);
        Assert.Equal(1, (int)order.orderedBy.id);
        Assert.Equal("Chris", (string)order.orderedBy.firstName);
        Assert.Equal("Klug", (string)order.orderedBy.lastName);
    }
}
