using AutoMapper;
using MicroserviceECommerce.Discount.Dtos.CouponDtos;
using MicroserviceECommerce.Discount.Entities.Models;

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
