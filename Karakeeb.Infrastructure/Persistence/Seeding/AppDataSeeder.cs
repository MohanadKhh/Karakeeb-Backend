using Karakeeb.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Karakeeb.Infrastructure;

public static class AppDataSeeder
{
    private sealed record SeedUser(int Id, string Email, string UserName, string FullName, string Role, string Password);

    public static async Task SeedAsync(AppDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager)
    {
        /**************************************************************************************/
        //Seeding Roles And Users
        var roles = new[] { "Admin", "User" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole<int>(role));
            }
        }

        var users = new[]
        {
            new SeedUser(1, "admin@karakeeb.com", "admin", "System Admin", "Admin", "Admin123!"),
            new SeedUser(2, "user1@karakeeb.com", "user1", "Default User 1", "User", "User123!"),
            new SeedUser(3, "user2@karakeeb.com", "user2", "Default User 2", "User", "User123!"),
            new SeedUser(4, "user3@karakeeb.com", "user3", "Default User 3", "User", "User123!"),
            new SeedUser(5, "user4@karakeeb.com", "user4", "Default User 4", "User", "User123!")
        };

        foreach (var seedUser in users)
        {
            var existingUser = await userManager.FindByEmailAsync(seedUser.Email);
            if (existingUser != null)
            {
                continue;
            }

            var user = new ApplicationUser
            {
                UserName = seedUser.UserName,
                Email = seedUser.Email,
                EmailConfirmed = true,
                FullName = seedUser.FullName,
                CreatedAt = DateTime.UtcNow,
                IsVerified = true,
                Rating = 0m
            };

            var createResult = await userManager.CreateAsync(user, seedUser.Password);
            if (createResult.Succeeded)
            {
                await userManager.AddToRoleAsync(user, seedUser.Role);
            }
        }

        /**************************************************************************************/

        if (!await context.ScrapCategories.AnyAsync())
        {
            await context.ScrapCategories.AddRangeAsync(
                new ScrapCategory { Name = "Metals", Description = "Ferrous and non-ferrous metals", ImageUrl = "https://example.com/categories/metals.png" },
                new ScrapCategory { Name = "Plastics", Description = "Recyclable plastics", ImageUrl = "https://example.com/categories/plastics.png" },
                new ScrapCategory { Name = "Paper", Description = "Paper and cardboard", ImageUrl = "https://example.com/categories/paper.png" },
                new ScrapCategory { Name = "Electronics", Description = "Electronic waste", ImageUrl = "https://example.com/categories/electronics.png" },
                new ScrapCategory { Name = "Glass", Description = "Glass items", ImageUrl = "https://example.com/categories/glass.png" }
            );
            await context.SaveChangesAsync();
        }

        /**************************************************************************************/

        if (!await context.ScrapItems.AnyAsync())
        {
            var createdAt = new DateTime(2024, 1, 1);
            var updatedAt = new DateTime(2024, 1, 15);
            var scrapCategories = await context.ScrapCategories.OrderBy(c => c.Id).Take(5).ToListAsync();

            await context.ScrapItems.AddRangeAsync(
                new ScrapItem { Title = "Steel Beams", Description = "Used steel beams", Quantity = 1200m, Unit = "Kg", Price = 0.45m, PriceUnit = "Per Kg", Location = "Riyadh", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 2, CategoryId = scrapCategories[0].Id },
                new ScrapItem { Title = "Copper Wire", Description = "Insulated copper wire", Quantity = 350m, Unit = "Kg", Price = 3.10m, PriceUnit = "Per Kg", Location = "Jeddah", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 2, CategoryId = scrapCategories[0].Id },
                new ScrapItem { Title = "Aluminum Sheets", Description = "Aluminum sheets offcuts", Quantity = 500m, Unit = "Kg", Price = 1.25m, PriceUnit = "Per Kg", Location = "Dammam", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 3, CategoryId = scrapCategories[0].Id },
                new ScrapItem { Title = "Plastic Bottles", Description = "Mixed PET bottles", Quantity = 800m, Unit = "Kg", Price = 0.20m, PriceUnit = "Per Kg", Location = "Riyadh", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 4, CategoryId = scrapCategories[1].Id },
                new ScrapItem { Title = "HDPE Scrap", Description = "HDPE containers", Quantity = 600m, Unit = "Kg", Price = 0.30m, PriceUnit = "Per Kg", Location = "Jeddah", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 5, CategoryId = scrapCategories[1].Id },
                new ScrapItem { Title = "Cardboard Boxes", Description = "Flattened cardboard", Quantity = 1000m, Unit = "Kg", Price = 0.12m, PriceUnit = "Per Kg", Location = "Dammam", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 3, CategoryId = scrapCategories[1].Id },
                new ScrapItem { Title = "Office Paper", Description = "Shredded office paper", Quantity = 420m, Unit = "Kg", Price = 0.10m, PriceUnit = "Per Kg", Location = "Riyadh", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 2, CategoryId = scrapCategories[2].Id },
                new ScrapItem { Title = "Newspaper Bundles", Description = "Old newspapers", Quantity = 300m, Unit = "Kg", Price = 0.08m, PriceUnit = "Per Kg", Location = "Jeddah", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 3, CategoryId = scrapCategories[2].Id },
                new ScrapItem { Title = "Circuit Boards", Description = "Mixed PCBs", Quantity = 200m, Unit = "Kg", Price = 4.50m, PriceUnit = "Per Kg", Location = "Dammam", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 4, CategoryId = scrapCategories[2].Id },
                new ScrapItem { Title = "Old Laptops", Description = "Broken laptops", Quantity = 75m, Unit = "Piece", Price = 18.00m, PriceUnit = "Per Piece", Location = "Riyadh", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 5, CategoryId = scrapCategories[3].Id },
                new ScrapItem { Title = "Mobile Phones", Description = "Used phones", Quantity = 120m, Unit = "Piece", Price = 6.50m, PriceUnit = "Per Piece", Location = "Jeddah", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 4, CategoryId = scrapCategories[3].Id },
                new ScrapItem { Title = "Glass Bottles", Description = "Clear glass bottles", Quantity = 900m, Unit = "Kg", Price = 0.15m, PriceUnit = "Per Kg", Location = "Dammam", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 2, CategoryId = scrapCategories[3].Id },
                new ScrapItem { Title = "Glass Jars", Description = "Mixed glass jars", Quantity = 650m, Unit = "Kg", Price = 0.14m, PriceUnit = "Per Kg", Location = "Riyadh", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 3, CategoryId = scrapCategories[4].Id },
                new ScrapItem { Title = "Broken Glass", Description = "Crushed glass", Quantity = 1100m, Unit = "Kg", Price = 0.09m, PriceUnit = "Per Kg", Location = "Jeddah", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 4, CategoryId = scrapCategories[4].Id },
                new ScrapItem { Title = "Mixed Scrap", Description = "Mixed recyclable scrap", Quantity = 500m, Unit = "Kg", Price = 0.25m, PriceUnit = "Per Kg", Location = "Dammam", IsAvailable = true, CreatedAt = createdAt, UpdatedAt = updatedAt, SellerId = 5, CategoryId = scrapCategories[4].Id }
            );
            await context.SaveChangesAsync();
        }

        /**************************************************************************************/

        if (!await context.ScrapImages.AnyAsync())
        {
            var uploadedAt = new DateTime(2024, 1, 5);
            var scrapItems = await context.ScrapItems.OrderBy(s => s.Id).Take(5).ToListAsync();

            await context.ScrapImages.AddRangeAsync(
                new ScrapImage { ImageUrl = "https://example.com/images/scrap-1.jpg", IsPrimary = true, UploadedAt = uploadedAt, ScrapItemId = scrapItems[0].Id },
                new ScrapImage { ImageUrl = "https://example.com/images/scrap-2.jpg", IsPrimary = true, UploadedAt = uploadedAt, ScrapItemId = scrapItems[1].Id },
                new ScrapImage { ImageUrl = "https://example.com/images/scrap-3.jpg", IsPrimary = true, UploadedAt = uploadedAt, ScrapItemId = scrapItems[2].Id },
                new ScrapImage { ImageUrl = "https://example.com/images/scrap-4.jpg", IsPrimary = true, UploadedAt = uploadedAt, ScrapItemId = scrapItems[3].Id },
                new ScrapImage { ImageUrl = "https://example.com/images/scrap-5.jpg", IsPrimary = true, UploadedAt = uploadedAt, ScrapItemId = scrapItems[4].Id }
            );
            await context.SaveChangesAsync();
        }

        /**************************************************************************************/

        if (!await context.Offers.AnyAsync())
        {
            var createdAt = new DateTime(2024, 1, 10);
            var updatedAt = new DateTime(2024, 1, 12);
            var scrapItems = await context.ScrapItems.OrderBy(s => s.Id).Take(5).ToListAsync();

            await context.Offers.AddRangeAsync(
                new Offer { OfferedPrice = 500m, Note = "Quick pickup", Status = OfferStatus.Pending, CreatedAt = createdAt, UpdatedAt = updatedAt, ScrapItemId = scrapItems[0].Id, BuyerId = 1 },
                new Offer { OfferedPrice = 950m, Note = "Bulk purchase", Status = OfferStatus.Accepted, CreatedAt = createdAt, UpdatedAt = updatedAt, ScrapItemId = scrapItems[1].Id, BuyerId = 2 },
                new Offer { OfferedPrice = 600m, Note = "Include transport", Status = OfferStatus.Pending, CreatedAt = createdAt, UpdatedAt = updatedAt, ScrapItemId = scrapItems[2].Id, BuyerId = 3 },
                new Offer { OfferedPrice = 350m, Note = "Ready today", Status = OfferStatus.Rejected, CreatedAt = createdAt, UpdatedAt = updatedAt, ScrapItemId = scrapItems[3].Id, BuyerId = 4 },
                new Offer { OfferedPrice = 720m, Note = "Flexible timing", Status = OfferStatus.Pending, CreatedAt = createdAt, UpdatedAt = updatedAt, ScrapItemId = scrapItems[4].Id, BuyerId = 5 }
            );
            await context.SaveChangesAsync();
        }

        /**************************************************************************************/

        if (!await context.Deals.AnyAsync())
        {
            var createdAt = new DateTime(2024, 1, 20);
            var updatedAt = new DateTime(2024, 1, 22);
            var offers = await context.Offers.OrderBy(o => o.Id).Take(5).ToListAsync();
            var scrapItems = await context.ScrapItems.OrderBy(s => s.Id).Take(5).ToListAsync();

            await context.Deals.AddRangeAsync(
                new Deal { FinalPrice = 520m, Status = DealStatus.Pending, SellerPhone = "+966500000001", SellerEmail = "seller1@example.com", CreatedAt = createdAt, UpdatedAt = updatedAt, OfferId = offers[0].Id, ScrapItemId = scrapItems[0].Id, SellerId = 1, BuyerId = 1 },
                new Deal { FinalPrice = 980m, Status = DealStatus.Completed, SellerPhone = "+966500000002", SellerEmail = "seller2@example.com", CreatedAt = createdAt, UpdatedAt = updatedAt, OfferId = offers[1].Id, ScrapItemId = scrapItems[1].Id, SellerId = 2, BuyerId = 2 },
                new Deal { FinalPrice = 610m, Status = DealStatus.Pending, SellerPhone = "+966500000003", SellerEmail = "seller3@example.com", CreatedAt = createdAt, UpdatedAt = updatedAt, OfferId = offers[2].Id, ScrapItemId = scrapItems[2].Id, SellerId = 3, BuyerId = 3 },
                new Deal { FinalPrice = 360m, Status = DealStatus.Cancelled, SellerPhone = "+966500000004", SellerEmail = "seller4@example.com", CreatedAt = createdAt, UpdatedAt = updatedAt, OfferId = offers[3].Id, ScrapItemId = scrapItems[3].Id, SellerId = 4, BuyerId = 4 },
                new Deal { FinalPrice = 750m, Status = DealStatus.Pending, SellerPhone = "+966500000005", SellerEmail = "seller5@example.com", CreatedAt = createdAt, UpdatedAt = updatedAt, OfferId = offers[4].Id, ScrapItemId = scrapItems[4].Id, SellerId = 5, BuyerId = 5 }
            );
            await context.SaveChangesAsync();
        }
    }
}
