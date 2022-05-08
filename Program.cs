using Microsoft.EntityFrameworkCore;
using NextSoft.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("Context")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
