using System.Reflection;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public DbSet<CouponModel> Coupons { get; set; }
    public DbSet<PriceListModel> PriceLists { get; set; }
    public DbSet<PromotionModel> Promotions { get; set; }
    public DbSet<OrderModel> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
