using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class CouponModel
{
    [Key]
    public int CouponId { get; set; }
    public OfferType OfferType { get; set; }
    public float CouponOffer { get; set; }
    public OrderModel Order { get; set; }
    public int OrderId { get; set; }
}
