using KomOchHämta.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<AccountService>();
builder.Services.AddTransient<DataService>();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(o => o.MapControllers());

app.Run();