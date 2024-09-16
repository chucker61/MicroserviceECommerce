using AutoMapper;
using MicroserviceECommerce.Discount.Dtos.DiscountDtos;
using MicroserviceECommerce.Discount.Entities;

namespace MicroserviceECommerce.Discount.Utilities.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Coupon, ResultDiscountCouponDto>().ReverseMap();
            CreateMap<Coupon, GetByIdDiscountCouponDto>().ReverseMap();
            CreateMap<Coupon, CreateDiscountCouponDto>().ReverseMap();
            CreateMap<Coupon, UpdateDiscountCouponDto>().ReverseMap();
        }
    }
}
