using FluentValidation;
using Karakeeb.Application;
using Karakeeb.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Scalar.AspNetCore;

namespace Karakeeb.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            //Add Services of MediatR and Validation Behavior and Pipelines
            builder.Services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(typeof(IAssemblyMarker).Assembly);
            });

            builder.Services.AddValidatorsFromAssembly(typeof(IAssemblyMarker).Assembly);

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //Add Services of Infrastructure Layer
            builder.Services.AddInfrastructure(builder.Configuration);

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                AppDataSeeder.SeedAsync(dbContext, userManager, roleManager).GetAwaiter().GetResult();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
