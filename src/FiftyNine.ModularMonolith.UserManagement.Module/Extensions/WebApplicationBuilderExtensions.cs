using FiftyNine.ModularMonolith.UserManagement.Module.Data;

namespace FiftyNine.ModularMonolith.UserManagement.Module.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddUsersModule(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers()
                        .AddApplicationPart(typeof(WebApplicationBuilderExtensions).Assembly);

        builder.Services.AddSingleton<Data.IUsers, Users>()
                        .AddSingleton(x => (IUsers)x.GetRequiredService<Data.IUsers>());

        return builder;
    }
}
