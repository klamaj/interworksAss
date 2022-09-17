using API.Data;
using API.DTOs;
using API.Interfaces;
using API.Models;
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

            var priceList = await _offer.GetPriceListOffer(item.OrderId);
            var promotion = await _offer.GetPromotionOffer(item.OrderId);
            var coupon = await _offer.GetCouponOffer(item.OrderId);

            var calcPriceList = _offer.CalculateOffer(priceList, item.OrderTotal);
            ord.PriceList = calcPriceList.CalculatedOffer;

            var calcPromotion = _offer.CalculateOffer(promotion, calcPriceList.CalculatedPrice);
            ord.Promotion = calcPromotion.CalculatedOffer;

            var calcCoupon = _offer.CalculateOffer(coupon, calcPromotion.CalculatedPrice);
            ord.Coupon = calcCoupon.CalculatedOffer;

            ord.FinalPrice = calcCoupon.CalculatedPrice;

            order.Add(ord);
        }

        return Ok(order);
    }
}
