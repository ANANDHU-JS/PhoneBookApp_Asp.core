using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhoneBook_App__Anandhu_JS.Areas.Identity.Data;
using PhoneBook_App__Anandhu_JS.Data;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PhoneBook_App__Anandhu_JS__AuthDbContextConnection") ?? throw new InvalidOperationException("Connection string 'PhoneBook_App__Anandhu_JS__AuthDbContextConnection' not found.");

builder.Services.AddDbContext<PhoneBook_App__Anandhu_JS__AuthDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<PhoneBook_App__Anandhu_JS__AuthDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PhoneBooks}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
