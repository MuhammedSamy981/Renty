
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Renty.Domain.Entities;

namespace Renty.Infrastructure.Data
{
    public static class ApplicationDbHelper
    {
        public static string[] roles = new[] { "Manager", "Admin", "User" };

    public static async Task SeedDataAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager
    , ApplicationDbContext context)
    {
        await SeedRolesAsync(roleManager);
        await SeedUsersAsync(userManager);
        await SeedProductsAsync(context);
        await SeedRatingsAsync(context);
        await SeedImagesAsync(context);
    }
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            
          if (await roleManager.Roles.AnyAsync()) return;


                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            


        }

        private static async Task SeedUsersAsync(UserManager<User> userManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var users = new List<User>
        {            new User
            {
                FirstName = "Muhammad",
                LastName = "Samy",
                UserName = "muhammed.samy@example.com",
                Email = "muhammed.samy@example.com",
                PhoneNumber = "687443593789",
                CountryId = 1,
                CityId = 3,
                AreaId = 120,
                EmailConfirmed = true
            },
                        new User
            {
                FirstName = "Ahmed",
                LastName = "Mohamed",
                UserName = "ahmed.mohamed@example.com",
                Email = "ahmed.mohamed@example.com",
                PhoneNumber = "836940857",
                CountryId = 1,
                CityId = 3,
                AreaId = 98,
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "John",
                LastName = "Doe",
                UserName = "john.doe@example.com",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                CountryId = 1,
                CityId = 1,
                AreaId = 1,
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "Jane",
                LastName = "Smith",
                UserName = "jane.smith@example.com",
                Email = "jane.smith@example.com",
                PhoneNumber = "2345678901",
                CountryId = 1,
                CityId = 3,
                AreaId = 100,
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "Robert",
                LastName = "Johnson",
                UserName = "robert.johnson@example.com",
                Email = "robert.johnson@example.com",
                PhoneNumber = "3456789012",
                CountryId = 1,
                CityId = 1,
                AreaId = 5,
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "Emily",
                LastName = "Williams",
                UserName = "emily.williams@example.com",
                Email = "emily.williams@example.com",
                PhoneNumber = "4567890123",
                CountryId = 1,
                CityId = 3,
                AreaId = 110,
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "Michael",
                LastName = "Brown",
                UserName = "michael.brown@example.com",
                Email = "michael.brown@example.com",
                PhoneNumber = "5678901234",
                CountryId = 1,
                CityId = 1,
                AreaId = 8,
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "Sarah",
                LastName = "Davis",
                UserName = "sarah.davis@example.com",
                Email = "sarah.davis@example.com",
                PhoneNumber = "6789012345",
                CountryId = 1,
                CityId = 3,
                AreaId = 120,
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "David",
                LastName = "Miller",
                UserName = "david.miller@example.com",
                Email = "david.miller@example.com",
                PhoneNumber = "7890123456",
                CountryId = 1,
                CityId = 1,
                AreaId = 11,
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "Jessica",
                LastName = "Wilson",
                UserName = "jessica.wilson@example.com",
                Email = "jessica.wilson@example.com",
                PhoneNumber = "8901234567",
                CountryId = 1,
                CityId = 1,
                AreaId = 12,
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "Thomas",
                LastName = "Moore",
                UserName = "thomas.moore@example.com",
                Email = "thomas.moore@example.com",
                PhoneNumber = "9012345678",
                CountryId = 1,
                CityId = 1,
                AreaId = 14,
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "Lisa",
                LastName = "Taylor",
                UserName = "lisa.taylor@example.com",
                Email = "lisa.taylor@example.com",
                PhoneNumber = "0123456789",
                CountryId = 1,
                CityId = 1,
                AreaId = 15,
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "Jon",
                LastName = "Ronny",
                UserName = "jon.ronny@example.com",
                Email = "jon.ronny@example.com",
                PhoneNumber = "1122334455",
                CountryId = 1,
                CityId = 1,
                AreaId = 17,
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "Mark",
                LastName = "Allen",
                UserName = "mark.allen@example.com",
                Email = "mark.allen@example.com",
                PhoneNumber = "2233445566",
                CountryId = 1,
                CityId = 3,
                AreaId = 130,
                EmailConfirmed = true
            }
        };

                           for (int i = 0; i < users.Count; i++)
                {

                   var result= await userManager.CreateAsync(users[i],"123");
                        
            if (result.Succeeded)
            {
                    if (i == 0 || i == 1)
                    {
                        await userManager.AddToRoleAsync(users[i], roles[i]);
                    }
                    else 
                    {
                        await userManager.AddToRoleAsync(users[i], roles[2]);
                    }
            } 

            
                }
    }



    private static async Task SeedProductsAsync(ApplicationDbContext context)
    {
        if (await context.Products.AnyAsync()) return;

        var users = await context.Users.ToListAsync();
        var random = new Random();

        var products = new List<Product>
        {
            new Product
            {
                Name = "Smartphone X",
                CategoryId = 7,
                Price = 799.99m,
                Description = "Latest smartphone with advanced features",
                AddingDate = DateTime.Now.AddDays(-10),
                Status = "accepted",
                UserId = users[2].Id
            },
            new Product
            {
                Name = "Laptop Pro",
                CategoryId = 6,
                Price = 1299.99m,
                Description = "High-performance laptop for professionals",
                AddingDate = DateTime.Now.AddDays(-8),
                Status = "accepted",
                UserId = users[3].Id
            },
            new Product
            {
                Name = "Wireless Headphones",
                CategoryId = 7,
                Price = 199.99m,
                Description = "Noise-cancelling wireless headphones",
                AddingDate = DateTime.Now.AddDays(-15),
                Status = "accepted",
                UserId = users[4].Id
            },
            new Product
            {
                Name = "Smart Watch",
                CategoryId = 7,
                Price = 249.99m,
                Description = "Fitness tracker and smart notifications",
                AddingDate = DateTime.Now.AddDays(-5),
                Status = "accepted",
                UserId = users[5].Id
            },
            new Product
            {
                Name = "Digital Camera",
                CategoryId = 13,
                Price = 599.99m,
                Description = "Professional DSLR camera",
                AddingDate = DateTime.Now.AddDays(-12),
                Status = "accepted",
                UserId = users[6].Id
            },
            new Product
            {
                Name = "Gaming Console",
                CategoryId = 9,
                Price = 499.99m,
                Description = "Next-gen gaming experience",
                AddingDate = DateTime.Now.AddDays(-20),
                Status = "accepted",
                UserId = users[7].Id
            },
            new Product
            {
                Name = "Bluetooth Speaker",
                CategoryId = 7,
                Price = 129.99m,
                Description = "Portable speaker with great sound",
                AddingDate = DateTime.Now.AddDays(-7),
                Status = "accepted",
                UserId = users[8].Id
            },
            new Product
            {
                Name = "E-Reader",
                CategoryId = 7,
                Price = 139.99m,
                Description = "Paper-like reading experience",
                AddingDate = DateTime.Now.AddDays(-3),
                Status = "accepted",
                UserId = users[9].Id
            },
            new Product
            {
                Name = "Tablet",
                CategoryId = 7,
                Price = 349.99m,
                Description = "Versatile tablet for work and play",
                AddingDate = DateTime.Now.AddDays(-9),
                Status = "accepted",
                UserId = users[10].Id
            },
            new Product
            {
                Name = "Fitness Tracker",
                CategoryId = 12,
                Price = 99.99m,
                Description = "Track your workouts and health metrics",
                AddingDate = DateTime.Now.AddDays(-14),
                Status = "accepted",
                UserId = users[11].Id
            },
            new Product
            {
                Name = "External SSD",
                CategoryId = 6,
                Price = 129.99m,
                Description = "Fast external storage solution",
                AddingDate = DateTime.Now.AddDays(-6),
                Status = "accepted",
                UserId = users[12].Id
            },
            new Product
            {
                Name = "Wireless Keyboard",
                CategoryId = 6,
                Price = 79.99m,
                Description = "Ergonomic wireless keyboard",
                AddingDate = DateTime.Now.AddDays(-2),
                Status = "accepted",
                UserId = users[13].Id
            }
        };

        await context.Products.AddRangeAsync(products);
        await context.SaveChangesAsync();
    }

    private static async Task SeedRatingsAsync(ApplicationDbContext context)
    {
        if (await context.Ratings.AnyAsync()) return;

        var users = await context.Users.ToListAsync();
        var products = await context.Products.ToListAsync();
        var random = new Random();

        var ratings = new List<Rating>
        {
            new Rating
            {
                Value = 5,
                Comment = "Excellent product!",
                Datetime = DateTime.Now.AddDays(-1).ToString(),
                Report = false,
                ProductId = products[0].Id,
                UserId = users[2].Id
            },
            new Rating
            {
                Value = 4,
                Comment = "Very good, but could be better",
                Datetime = DateTime.Now.AddDays(-2).ToString(),
                Report = false,
                ProductId = products[0].Id,
                UserId = users[4].Id
            },
            new Rating
            {
                Value = 3,
                Comment = "Average performance",
                Datetime = DateTime.Now.AddDays(-3).ToString(),
                Report = false,
                ProductId = products[1].Id,
                UserId = users[2].Id
            },
            new Rating
            {
                Value = 5,
                Comment = "Perfect! Exceeded my expectations",
                Datetime = DateTime.Now.AddDays(-4).ToString(),
                Report = false,
                ProductId = products[2].Id,
                UserId = users[5].Id
            },
            new Rating
            {
                Value = 2,
                Comment = "Not as described",
                Datetime = DateTime.Now.AddDays(-5).ToString(),
                Report = true,
                ProductId = products[3].Id,
                UserId = users[6].Id
            },
            new Rating
            {
                Value = 1,
                Comment = "Defective product",
                Datetime = DateTime.Now.AddDays(-6).ToString(),
                Report = true,
                ProductId = products[4].Id,
                UserId = users[7].Id
            },
            new Rating
            {
                Value = 4,
                Comment = "Great value for money",
                Datetime = DateTime.Now.AddDays(-7).ToString(),
                Report = false,
                ProductId = products[5].Id,
                UserId = users[8].Id
            },
            new Rating
            {
                Value = 5,
                Comment = "Amazing quality",
                Datetime = DateTime.Now.AddDays(-8).ToString(),
                Report = false,
                ProductId = products[6].Id,
                UserId = users[9].Id
            },
            new Rating
            {
                Value = 3,
                Comment = "Could be improved",
                Datetime = DateTime.Now.AddDays(-9).ToString(),
                Report = false,
                ProductId = products[7].Id,
                UserId = users[10].Id
            },
            new Rating
            {
                Value = 4,
                Comment = "Works as expected",
                Datetime = DateTime.Now.AddDays(-10).ToString(),
                Report = false,
                ProductId = products[8].Id,
                UserId = users[11].Id
            },
            new Rating
            {
                Value = 5,
                Comment = "Highly recommended",
                Datetime = DateTime.Now.AddDays(-11).ToString(),
                Report = false,
                ProductId = products[9].Id,
                UserId = users[12].Id
            },
            new Rating
            {
                Value = 2,
                Comment = "Poor customer support",
                Datetime = DateTime.Now.AddDays(-12).ToString(),
                Report = true,
                ProductId = products[10].Id,
                UserId = users[13].Id
            }
        };

        await context.Ratings.AddRangeAsync(ratings);
        await context.SaveChangesAsync();
    }

    private static async Task SeedImagesAsync(ApplicationDbContext context)
    {
        if (await context.Images.AnyAsync()) return;

        var products = await context.Products.ToListAsync();
        var random = new Random();

        var images = new List<Image>
        {
            new Image
            {
                Url = "https://images.unsplash.com/photo-1601784551446-20c9e07cdbdb",
                ProductId = products[0].Id
            },
            new Image
            {
                Url = "https://images.unsplash.com/photo-1601784551446-20c9e07cdbdb",
                ProductId = products[0].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1601784551446-20c9e07cdbdb",
                ProductId = products[0].Id
            },
            new Image
            {
                Url = "https://images.unsplash.com/photo-1601784551446-20c9e07cdbdb",
                ProductId = products[0].Id
            },
            new Image
            {
                Url = "https://images.unsplash.com/photo-1611186871348-b1ce696e52c9",
                ProductId = products[1].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1611186871348-b1ce696e52c9",
                ProductId = products[1].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1611186871348-b1ce696e52c9",
                ProductId = products[1].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1611186871348-b1ce696e52c9",
                ProductId = products[1].Id
            },
            new Image
            {
                Url = "https://images.pexels.com/photos/1649771/pexels-photo-1649771.jpeg",
                ProductId = products[2].Id
            },
                        new Image
            {
                Url = "https://images.pexels.com/photos/1649771/pexels-photo-1649771.jpeg",
                ProductId = products[2].Id
            },
                        new Image
            {
                Url = "https://images.pexels.com/photos/1649771/pexels-photo-1649771.jpeg",
                ProductId = products[2].Id
            },
                        new Image
            {
                Url = "https://images.pexels.com/photos/1649771/pexels-photo-1649771.jpeg",
                ProductId = products[2].Id
            },
            new Image
            {
                Url = "https://images.unsplash.com/photo-1523275335684-37898b6baf30",
                ProductId = products[3].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1523275335684-37898b6baf30",
                ProductId = products[3].Id
            },
            new Image
            {
                Url = "https://images.unsplash.com/photo-1523275335684-37898b6baf30",
                ProductId = products[3].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1523275335684-37898b6baf30",
                ProductId = products[3].Id
            },
            new Image
            {
                Url = "https://images.unsplash.com/photo-1516035069371-29a1b244cc32",
                ProductId = products[4].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1516035069371-29a1b244cc32",
                ProductId = products[4].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1516035069371-29a1b244cc32",
                ProductId = products[4].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1516035069371-29a1b244cc32",
                ProductId = products[4].Id
            },
            new Image
            {
                Url = "https://images.unsplash.com/photo-1607853202273-797f1c22a38e",
                ProductId = products[5].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1607853202273-797f1c22a38e",
                ProductId = products[5].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1607853202273-797f1c22a38e",
                ProductId = products[5].Id
            },new Image
                        {
                Url = "https://images.unsplash.com/photo-1607853202273-797f1c22a38e",
                ProductId = products[5].Id
            },
            new Image
            {
                Url = "https://images.unsplash.com/photo-1572569511254-d8f925fe2cbb",
                ProductId = products[6].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1572569511254-d8f925fe2cbb",
                ProductId = products[6].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1572569511254-d8f925fe2cbb",
                ProductId = products[6].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1572569511254-d8f925fe2cbb",
                ProductId = products[6].Id
            },
            new Image
            {
                Url = "https://cdn.pixabay.com/photo/2015/05/02/18/59/kindle-750304_1280.jpg",
                ProductId = products[7].Id
            },
                        new Image
            {
                Url = "https://cdn.pixabay.com/photo/2015/05/02/18/59/kindle-750304_1280.jpg",
                ProductId = products[7].Id
            },
                        new Image
            {
                Url = "https://cdn.pixabay.com/photo/2015/05/02/18/59/kindle-750304_1280.jpg",
                ProductId = products[7].Id
            },
                        new Image
            {
                Url = "https://cdn.pixabay.com/photo/2015/05/02/18/59/kindle-750304_1280.jpg",
                ProductId = products[7].Id
            },
            new Image
            {
                Url = "https://images.pexels.com/photos/1334597/pexels-photo-1334597.jpeg",
                ProductId = products[8].Id
            },
                        new Image
            {
                Url = "https://images.pexels.com/photos/1334597/pexels-photo-1334597.jpeg",
                ProductId = products[8].Id
            },
                        new Image
            {
                Url = "https://images.pexels.com/photos/1334597/pexels-photo-1334597.jpeg",
                ProductId = products[8].Id
            },
                        new Image
            {
                Url = "https://images.pexels.com/photos/1334597/pexels-photo-1334597.jpeg",
                ProductId = products[8].Id
            },
            new Image
            {
                Url = "https://images.unsplash.com/photo-1576243345690-4e4b79b63288",
                ProductId = products[9].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1576243345690-4e4b79b63288",
                ProductId = products[9].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1576243345690-4e4b79b63288",
                ProductId = products[9].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1576243345690-4e4b79b63288",
                ProductId = products[9].Id
            },
            new Image
            {
                Url = "https://images.unsplash.com/photo-1591488320449-011701bb6704",
                ProductId = products[10].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1591488320449-011701bb6704",
                ProductId = products[10].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1591488320449-011701bb6704",
                ProductId = products[10].Id
            },
                        new Image
            {
                Url = "https://images.unsplash.com/photo-1591488320449-011701bb6704",
                ProductId = products[10].Id
            },
             new Image
            {
                Url = "https://images.pexels.com/photos/2115257/pexels-photo-2115257.jpeg",
                ProductId = products[11].Id
            },
            new Image
            {
                Url = "https://images.pexels.com/photos/2115257/pexels-photo-2115257.jpeg",
                ProductId = products[11].Id
            },
             new Image
            {
                Url = "https://images.pexels.com/photos/2115257/pexels-photo-2115257.jpeg",
                ProductId = products[11].Id
            },
            new Image
            {
                Url = "https://images.pexels.com/photos/2115257/pexels-photo-2115257.jpeg",
                ProductId = products[11].Id
            }
        };

        await context.Images.AddRangeAsync(images);
        await context.SaveChangesAsync();
    }


    }
}


