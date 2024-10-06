using AutoMapper;
using MicroserviceECommerce.Cargo.Context;
using MicroserviceECommerce.Cargo.Entities.Dtos.CargoCompanyDtos;
using MicroserviceECommerce.Cargo.Entities.Models;
using MicroserviceECommerce.Cargo.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.Cargo.Services
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CargoCompanyService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            var cargoCompany = _mapper.Map<CargoCompany>(createCargoCompanyDto);
            _context.Set<CargoCompany>().Add(cargoCompany);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCargoCompanyAsync(string id)
        {
            var cargoCompany = await _context.Set<CargoCompany>().FindAsync(id);
            if (cargoCompany == null)
            {
                throw new Exception("Cargo company not found");
            }
            _context.Set<CargoCompany>().Remove(cargoCompany);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompaniesAsync()
        {
            var result = await _context.Set<CargoCompany>().ToListAsync();
            var cargoCompanies = _mapper.Map<List<ResultCargoCompanyDto>>(result);
            return cargoCompanies;
        }

        public async Task<GetByIdCargoCompanyDto> GetByIdCargoCompanyAsync(string id)
        {
            var cargoCompany = await _context.Set<CargoCompany>().FindAsync(id);
            var result = _mapper.Map<GetByIdCargoCompanyDto>(cargoCompany);
            return result;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var cargoCompany = _mapper.Map<CargoCompany>(updateCargoCompanyDto);
            _context.Set<CargoCompany>().Update(cargoCompany);
            await _context.SaveChangesAsync();
        }
    }
}
