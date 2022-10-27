using FiftyNine.ModularMonolith.OrderManagement.Module.Data;

namespace FiftyNine.ModularMonolith.OrderManagement.Module.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddOrdersModule(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers()
                        .AddApplicationPart(typeof(WebApplicationBuilderExtensions).Assembly);

        builder.Services.AddSingleton<IOrders, Orders>();

        return builder;
    }
}
