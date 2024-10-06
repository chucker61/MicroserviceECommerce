using AutoMapper;
using MicroserviceECommerce.Cargo.Entities.Dtos.CargoCompanyDtos;
using MicroserviceECommerce.Cargo.Entities.Dtos.CargoCustomerDtos;
using MicroserviceECommerce.Cargo.Entities.Dtos.CargoDetailDtos;
using MicroserviceECommerce.Cargo.Entities.Dtos.CargoOperationDtos;
using MicroserviceECommerce.Cargo.Entities.Models;

namespace MicroserviceECommerce.Cargo.Utilities.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CargoCompany, ResultCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, GetByIdCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, CreateCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, UpdateCargoCompanyDto>().ReverseMap();

            CreateMap<CargoDetail, ResultCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, GetByIdCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, CreateCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, UpdateCargoDetailDto>().ReverseMap();

            CreateMap<CargoOperation, ResultCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, GetByIdCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, CreateCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, UpdateCargoOperationDto>().ReverseMap();

            CreateMap<CargoCustomer, ResultCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, GetByIdCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, CreateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, UpdateCargoCustomerDto>().ReverseMap();
        }
    }
}
