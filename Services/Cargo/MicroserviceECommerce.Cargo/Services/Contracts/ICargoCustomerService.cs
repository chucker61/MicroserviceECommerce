using MicroserviceECommerce.Cargo.Entities.Dtos.CargoCustomerDtos;

namespace MicroserviceECommerce.Cargo.Services.Contracts
{
    public interface ICargoCustomerService
    {
        Task<List<ResultCargoCustomerDto>> GetAllCargoCustomersAsync();
        Task CreateCargoCustomerAsync(CreateCargoCustomerDto createCargoCustomerDto);
        Task UpdateCargoCustomerAsync(UpdateCargoCustomerDto updateCargoCustomerDto);
        Task DeleteCargoCustomerAsync(string id);
        Task<GetByIdCargoCustomerDto> GetByIdCargoCustomerAsync(string id);
    }
}
