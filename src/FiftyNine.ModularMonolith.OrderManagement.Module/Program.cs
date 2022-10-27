using FakeItEasy;
using FiftyNine.ModularMonolith.OrderManagement.Module.Extensions;
using FiftyNine.ModularMonolith.UserManagement;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.AddOrdersModule();

var usersFake = A.Fake<IUsers>();
A.CallTo(() => usersFake.WithId(1)).Returns(User.Create(1, "John", "Doe"));
builder.Services.AddSingleton(usersFake);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

// Required for testing...
public partial class Program
{

}