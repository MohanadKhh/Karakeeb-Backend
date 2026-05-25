using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Karakeeb.Application;

namespace Karakeeb.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                            IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddIdentity<ApplicationUser, IdentityRole<int>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IScrapCategoryRepository, ScrapCategoryRepository>();
        services.AddScoped<IScrapItemRepository, ScrapItemRepository>();
        services.AddScoped<IOfferRepository, OfferRepository>();
        services.AddScoped<IDealRepository, DealRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}