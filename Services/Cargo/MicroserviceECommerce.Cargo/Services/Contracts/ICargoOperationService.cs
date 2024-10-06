using MicroserviceECommerce.Cargo.Entities.Dtos.CargoOperationDtos;

namespace MicroserviceECommerce.Cargo.Services.Contracts
{
    public interface ICargoOperationService
    {
        Task<List<ResultCargoOperationDto>> GetAllCargoOperationsAsync();
        Task CreateCargoOperationAsync(CreateCargoOperationDto createCargoOperationDto);
        Task UpdateCargoOperationAsync(UpdateCargoOperationDto updateCargoOperationDto);
        Task DeleteCargoOperationAsync(string id);
        Task<GetByIdCargoOperationDto> GetByIdCargoOperationAsync(string id);
    }
}
