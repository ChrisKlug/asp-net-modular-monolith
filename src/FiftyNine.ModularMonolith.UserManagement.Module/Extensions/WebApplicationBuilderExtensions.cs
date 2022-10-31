using FiftyNine.ModularMonolith.UserManagement.Module.Data;

namespace FiftyNine.ModularMonolith.UserManagement.Module.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddUserManagement(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers()
                        .AddApplicationPart(typeof(WebApplicationBuilderExtensions).Assembly);

        builder.Services.AddSingleton<Users>()
                        .AddSingleton<Data.IUsers>(x => x.GetRequiredService<Users>())
                        .AddSingleton<IUsers>(x => x.GetRequiredService<Users>());

        return builder;
    }
}
