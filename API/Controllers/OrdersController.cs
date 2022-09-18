using API.Data;
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/v1.0/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly IOffers _offer;
    public OrdersController(DatabaseContext context, IOffers offer)
    {
        _offer = offer;
        _context = context;
    }

    // getORders
    [HttpGet("get")]
    public async Task<ActionResult<List<OrderDto>>> GetOrdersList()
    {
        
        var data = await _context.Orders.ToListAsync();

        List<OrderDto> order = new List<OrderDto>();

        foreach (var item in data)
        {
            OrderDto ord = new OrderDto();
            ord.OrderTotal = item.OrderTotal;
            ord.OrderId = item.OrderId;

            var price = item.OrderTotal;

            var priceList = await _offer.GetPriceListOffer(item.OrderId);
            var promotion = await _offer.GetPromotionOffer(item.OrderId);
            var coupon = await _offer.GetCouponOffer(item.OrderId);

            if (priceList != null) 
            {
                var calcPriceList = _offer.CalculateOffer(priceList, price);
                price = calcPriceList.CalculatedPrice;
                ord.PriceList = calcPriceList.CalculatedOffer;
            }

            if (promotion != null)
            {
                var calcPromotion = _offer.CalculateOffer(promotion, price);
                price = calcPromotion.CalculatedPrice;
                ord.Promotion = calcPromotion.CalculatedOffer;
            }

            if (coupon != null)
            {
                var calcCoupon = _offer.CalculateOffer(coupon, price);
                price = calcCoupon.CalculatedPrice;
                ord.Coupon = calcCoupon.CalculatedOffer;
            }

            ord.FinalPrice = price;

            order.Add(ord);
        }

        return Ok(order);
    }
}
