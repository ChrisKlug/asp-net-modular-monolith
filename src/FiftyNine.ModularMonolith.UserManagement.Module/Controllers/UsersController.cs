using Microsoft.AspNetCore.Mvc;

namespace FiftyNine.ModularMonolith.UserManagement.Module.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly Data.IUsers users;

    public UsersController(Data.IUsers users)
    {
        this.users = users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        var user = await users.WithId(id);

        return user == null ? NotFound() : user;
    }
}
