using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class PromotionModel
{
    [Key]
    public int PromotionId { get; set; }
    public OfferType OfferType { get; set; }
    public float PromotionOffer { get; set; }
    public OrderModel Order { get; set; }
    public int OrderId { get; set; }
}
