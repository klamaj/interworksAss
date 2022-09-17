namespace API.DTOs;

public class OrderDto
{
    public int OrderId { get; set; }
    public float OrderTotal { get; set; }
    public string PriceList { get; set; }
    public string Promotion { get; set; }
    public string Coupon { get; set; }
    public float FinalPrice { get; set; }
}
