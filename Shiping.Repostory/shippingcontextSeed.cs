using Microsoft.Extensions.Logging;
using Shipping.Data;
using Shipping.Data.Entities;
using System.Text.Json;

namespace Shipping.Repository
{
    public class shippingcontextSeed
    {
        public static async Task SeedAsync(ShippingDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.Governments != null && !context.Governments.Any())
                {
                    var governmentsData = File.ReadAllText("../Shiping.Repostory/seedDate/Governments.json");
                    var governments = JsonSerializer.Deserialize<List<Government>>(governmentsData);
                    if (governments is not null)
                        await context.Governments.AddRangeAsync(governments);
                }

                if (context.Cities != null && !context.Cities.Any())
                {
                    var citiesData = File.ReadAllText("../Shiping.Repostory/seedDate/Cities.json");
                    var cities = JsonSerializer.Deserialize<List<City>>(citiesData);
                    if (cities is not null)
                        await context.Cities.AddRangeAsync(cities);
                }

                if (context.Branches != null && !context.Branches.Any())
                {
                    var branchesData = File.ReadAllText("../Shiping.Repostory/seedDate/Branches.json");
                    var branches = JsonSerializer.Deserialize<List<Branch>>(branchesData);
                    if (branches is not null)
                        await context.Branches.AddRangeAsync(branches);
                }

                if (context.Users != null && !context.Users.Any())
                {
                    var usersData = File.ReadAllText("../Shiping.Repostory/seedDate/Users.json");
                    var users = JsonSerializer.Deserialize<List<User>>(usersData);
                    if (users is not null)
                        await context.Users.AddRangeAsync(users);
                }

               

                if (context.Orders != null && !context.Orders.Any())
                {
                    var ordersData = File.ReadAllText("../Shiping.Repostory/seedDate/Orders.json");
                    var orders = JsonSerializer.Deserialize<List<Order>>(ordersData);
                    if (orders is not null)
                        await context.Orders.AddRangeAsync(orders);
                }

                if (context.WeightPrices != null && !context.WeightPrices.Any())
                {
                    var weightPricesData = File.ReadAllText("../Shiping.Repostory/seedDate/WeightPrices.json");
                    var weightPrices = JsonSerializer.Deserialize<List<WeightPrice>>(weightPricesData);
                    if (weightPrices is not null)
                        await context.WeightPrices.AddRangeAsync(weightPrices);
                }

                if (context.Products != null && !context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Shiping.Repostory/seedDate/Products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    if (products is not null)
                        await context.Products.AddRangeAsync(products);
                }

                if (context.ShippingTypes != null && !context.ShippingTypes.Any())
                {
                    var shippingTypesData = File.ReadAllText("../Shiping.Repostory/seedDate/ShippingTypes.json");
                    var shippingTypes = JsonSerializer.Deserialize<List<ShippingType>>(shippingTypesData);
                    if (shippingTypes is not null)
                        await context.ShippingTypes.AddRangeAsync(shippingTypes);
                }

                if (context.Deliveries != null && !context.Deliveries.Any())
                {
                    var deliveriesData = File.ReadAllText("../Shiping.Repostory/seedDate/Deliveries.json");
                    var deliveries = JsonSerializer.Deserialize<List<Delivery>>(deliveriesData);
                    if (deliveries is not null)
                        await context.Deliveries.AddRangeAsync(deliveries);
                }

                if (context.Marchants != null && !context.Marchants.Any())
                {
                    var marchantsData = File.ReadAllText("../Shiping.Repostory/seedDate/Marchants.json");
                    var marchants = JsonSerializer.Deserialize<List<Marchant>>(marchantsData);
                    if (marchants is not null)
                        await context.Marchants.AddRangeAsync(marchants);
                }

                if (context.Permissions != null && !context.Permissions.Any())
                {
                    var permissionsData = File.ReadAllText("../Shiping.Repostory/seedDate/Permissions.json");
                    var permissions = JsonSerializer.Deserialize<List<Permission>>(permissionsData);
                    if (permissions is not null)
                        await context.Permissions.AddRangeAsync(permissions);
                }

                if (context.RejectionOrders != null && !context.RejectionOrders.Any())
                {
                    var rejectionOrdersData = File.ReadAllText("../Shiping.Repostory/seedDate/RejectionOrders.json");
                    var rejectionOrders = JsonSerializer.Deserialize<List<RejectionOrder>>(rejectionOrdersData);
                    if (rejectionOrders is not null)
                        await context.RejectionOrders.AddRangeAsync(rejectionOrders);
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<shippingcontextSeed>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }
    }
}
