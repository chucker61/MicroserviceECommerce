using MicroserviceECommerce.Cargo.Entities.Dtos.CargoDetailDtos;

namespace MicroserviceECommerce.Cargo.Services.Contracts
{
    public interface ICargoDetailService
    {
        Task<List<ResultCargoDetailDto>> GetAllCargoDetailsAsync();
        Task CreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto);
        Task UpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto);
        Task DeleteCargoDetailAsync(string id);
        Task<GetByIdCargoDetailDto> GetByIdCargoDetailAsync(string id);
    }
}
