using KomOchHämta.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<AccountService>();
builder.Services.AddTransient<DataService>();

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(connString));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddEntityFrameworkStores<ApplicationContext>()
	.AddDefaultTokenProviders();



builder.Services.ConfigureApplicationCookie(
	o => o.LoginPath = "/login");

builder.Services.AddHttpContextAccessor();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization(); 

app.UseStaticFiles();
app.UseEndpoints(o => o.MapControllers());

app.Run();