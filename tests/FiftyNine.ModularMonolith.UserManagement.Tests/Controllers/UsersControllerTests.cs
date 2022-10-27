using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;

namespace FiftyNine.ModularMonolith.UserManagement.Tests.Controllers;

public class UsersControllerTests
{
    [Fact]
    public async Task Returns_user_if_passed_correct_id1()
    {
        var application = new WebApplicationFactory<Program>();
        var client = application.CreateClient();

        var response = await client.GetAsync("/api/users/1");

        response.EnsureSuccessStatusCode();

        dynamic user = JObject.Parse(await response.Content.ReadAsStringAsync());

        Assert.Equal(1, (int)user.id);
        Assert.Equal("Chris", (string)user.firstName);
        Assert.Equal("Klug", (string)user.lastName);
    }
}
