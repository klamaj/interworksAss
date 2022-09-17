using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class PriceListModel
{
    [Key]
    public int PriceListId { get; set; }
    public OfferType OfferType { get; set; }
    public float PriceListOffer { get; set; }
    public OrderModel Order { get; set; }
    public int OrderId { get; set; }
}
