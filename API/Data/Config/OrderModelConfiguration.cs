using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Config;

public class OrderModelConfiguration : IEntityTypeConfiguration<OrderModel>
{
    public void Configure(EntityTypeBuilder<OrderModel> builder)
    {
        builder.HasOne(o => o.Coupon)
            .WithOne(c => c.Order)
            .HasForeignKey<CouponModel>(c => c.OrderId);

        builder.HasOne(o => o.PriceList)
            .WithOne(p => p.Order)
            .HasForeignKey<PriceListModel>(p => p.OrderId);

        builder.HasOne(o => o.Promotion)
            .WithOne(p => p.Order)
            .HasForeignKey<PromotionModel>(p => p.OrderId);
    }
}
