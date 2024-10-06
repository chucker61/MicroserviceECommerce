using MicroserviceECommerce.Cargo.Entities.Dtos.CargoCompanyDtos;

namespace MicroserviceECommerce.Cargo.Services.Contracts
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompanyDto>> GetAllCargoCompaniesAsync();
        Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
        Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
        Task DeleteCargoCompanyAsync(string id);
        Task<GetByIdCargoCompanyDto> GetByIdCargoCompanyAsync(string id);
    }
}
