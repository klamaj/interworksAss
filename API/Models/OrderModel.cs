using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class OrderModel
{   
    [Key]
    public int OrderId { get; set; }
    public float OrderTotal { get; set; }
    public PromotionModel Promotion { get; set; }
    public PriceListModel PriceList { get; set; }
    public CouponModel Coupon { get; set; }
}
