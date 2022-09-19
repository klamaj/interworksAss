using System.Reflection;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DatabaseContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, 
    UserRoles, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
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
