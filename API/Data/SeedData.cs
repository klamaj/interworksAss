using System.Text.Json;
using API.Models;

namespace API.Data;

public class SeedData
{
    public static async Task AddDefaultData(DatabaseContext context)
    {
        try
        {
            // Orders
            if (!context.Orders.Any())
            {   
                var data = await System.IO.File.ReadAllTextAsync("./Data/DefaultData/orders.json");
                var orders = JsonSerializer.Deserialize<List<OrderModel>>(data);

                if (orders is null) return;

                foreach(var order in orders)
                {
                    await context.Orders.AddAsync(order);
                }

                await context.SaveChangesAsync();
            }

            // Coupons
            if (!context.Coupons.Any())
            {
                var data = await System.IO.File.ReadAllTextAsync("./Data/DefaultData/coupons.json");
                var coupons = JsonSerializer.Deserialize<List<CouponModel>>(data);

                if (coupons is null) return;

                foreach (var coupon in coupons)
                {
                    await context.Coupons.AddAsync(coupon);
                }

                await context.SaveChangesAsync();
            }

            // PriceList
            if (!context.PriceLists.Any())
            {
                var data = await System.IO.File.ReadAllTextAsync("./Data/DefaultData/priceList.json");
                var priceLists = JsonSerializer.Deserialize<List<PriceListModel>>(data);

                if (priceLists is null) return;

                foreach (var priceList in priceLists)
                {
                    await context.PriceLists.AddAsync(priceList);
                }

                await context.SaveChangesAsync();
            }

            // Promotion
            if (!context.Promotions.Any())
            {
                var data = await System.IO.File.ReadAllTextAsync("./Data/DefaultData/promotion.json");
                var promotions = JsonSerializer.Deserialize<List<PromotionModel>>(data);

                if (promotions is null) return;

                foreach (var promo in promotions)
                {
                    await context.Promotions.AddAsync(promo);
                }

                await context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.ToString());
        }
    }
}
