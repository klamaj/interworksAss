using API.DTOs;

namespace API.Interfaces;

public interface IOffers
{
    Task<OfferDto> GetCouponOffer(int id);
    Task<OfferDto> GetPriceListOffer(int id);
    Task<OfferDto> GetPromotionOffer(int id);
    CalculatedOfferDto CalculateOffer(OfferDto offer, float price);
}
