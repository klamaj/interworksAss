using API.DTOs;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class Offers : IOffers
{
    private readonly DatabaseContext _context;
    public Offers(DatabaseContext context)
    {
        _context = context;
    }
    // CalculatOffer
    public CalculatedOfferDto CalculateOffer(OfferDto offer, float price)
    {
        if (offer.OfferType == Models.OfferType.Percentage)
        {
            var calcPrice = price - (price * (offer.Offer / 100));
            var calcOffer = price * (offer.Offer / 100);

            return new CalculatedOfferDto
            {
                CalculatedPrice = calcPrice,
                CalculatedOffer = "-" + calcOffer.ToString() + "(" + offer.Offer + "%)"
            };
        }
        else
        {
            var calcPrice = price - offer.Offer;
            return new CalculatedOfferDto
            {
                CalculatedPrice = calcPrice,
                CalculatedOffer = "-" + offer.Offer.ToString() + "€"
            };
        }
    }

    // GetCoupon
    public async Task<OfferDto> GetCouponOffer(int id)
    {
        var data = await _context.Coupons.FirstOrDefaultAsync(c => c.OrderId == id);
        return new OfferDto
        {
            OfferType = data.OfferType,
            Offer = data.CouponOffer
        };
    }
    // GetPriceList
    public async Task<OfferDto> GetPriceListOffer(int id)
    {
        var data = await _context.PriceLists.FirstOrDefaultAsync(p => p.OrderId == id);
        return new OfferDto
        {
            OfferType = data.OfferType,
            Offer = data.PriceListOffer
        };
    }
    // GetPromotion
    public async Task<OfferDto> GetPromotionOffer(int id)
    {
        var data = await _context.Promotions.FirstOrDefaultAsync(p => p.OrderId == id);
        return new OfferDto
        {
            OfferType = data.OfferType,
            Offer = data.PromotionOffer
        };
    }

}
