using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ListEmployees1.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<ListEmployees1Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ListEmployees1Context") ?? throw new InvalidOperationException("Connection string 'ListEmployees1Context' not found.")));

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(option =>
         {
             option.LoginPath = "/Home/Index";
             option.ExpireTimeSpan= TimeSpan.FromMinutes(20);
         });
        builder.Services.AddAuthorization();
        builder.Services.AddRazorPages();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{Id?}");
        app.MapRazorPages();
        app.Run();
    }
}