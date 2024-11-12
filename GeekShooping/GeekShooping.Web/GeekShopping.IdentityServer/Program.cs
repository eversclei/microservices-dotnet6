using GeekShopping.IdentityServer.Model.Context;
using GeekShopping.IdentityServer.Model;
using Microsoft.AspNetCore.Identity;
using GeekShopping.IdentityServer.Configuration;
using Microsoft.EntityFrameworkCore;
using GeekShopping.IdentityServer.Initializer;

namespace GeekShopping.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
  
            var connectionString = builder.Configuration["ConnectionString:DefaultConnection"];
            builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<SqlServerContext>().AddDefaultTokenProviders();
            builder.Services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents= true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            }).AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
            .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)  
            .AddInMemoryClients(IdentityConfiguration.Clients)
            .AddAspNetIdentity<ApplicationUser>();

            builder.Services.AddScoped<IDbInitializer, DbInitializer>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
            app.UseIdentityServer();
            app.UseAuthorization();

            IDbInitializer initializer = app.Services.CreateScope().ServiceProvider.GetService<IDbInitializer>();

            initializer.Initialize();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}