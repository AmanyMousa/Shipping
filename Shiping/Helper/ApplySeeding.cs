using Microsoft.EntityFrameworkCore;
using Shipping.Data;
using Shipping.Repository;


namespace Shipping.Helper
{
    public class ApplySeeding
    {
        public static async Task ApplyAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = services.GetRequiredService<ShippingDbContext>();
                    await context.Database.MigrateAsync();
                    await shippingcontextSeed.SeedAsync(context, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<ApplySeeding>();
                    logger.LogError(ex.Message);
                }
            }
        }
    }
}
