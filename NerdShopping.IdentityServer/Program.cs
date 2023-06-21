
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NerdShopping.IdentityServer.Configuration;
using NerdShopping.IdentityServer.Initializer;
using NerdShopping.IdentityServer.Model;
using NerdShopping.IdentityServer.Model.Context;
using NerdShopping.IdentityServer.Services;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<MysqlContext>(options =>
        options.UseMySql(builder.Configuration.GetConnectionString("MysqlContext"), new MySqlServerVersion(new Version(8, 0, 29))));

        builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MysqlContext>().AddDefaultTokenProviders();

        var builderSerives = builder.Services.AddIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
            options.EmitStaticAudienceClaim = true;
        }).AddInMemoryIdentityResources(IdentityConf.IdentityResources)
            .AddInMemoryApiScopes(IdentityConf.ApiScopes)
                .AddInMemoryClients(IdentityConf.Clients)
                    .AddAspNetIdentity<AppUser>();

        builder.Services.AddScoped<IDBInitializer, DBInitializer>();
        builder.Services.AddScoped<IProfileService, ProfileService>();

        builderSerives.AddDeveloperSigningCredential();


        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        var initializer = app.Services.CreateScope().ServiceProvider.GetService<IDBInitializer>();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseIdentityServer();

        app.UseAuthorization();

        initializer.Initialize();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}