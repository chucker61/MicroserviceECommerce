using AutoMapper;
using MicroserviceECommerce.Cargo.Context;
using MicroserviceECommerce.Cargo.Entities.Dtos.CargoOperationDtos;
using MicroserviceECommerce.Cargo.Entities.Models;
using MicroserviceECommerce.Cargo.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.Cargo.Services
{
    public class CargoOperationService : ICargoOperationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CargoOperationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCargoOperationAsync(CreateCargoOperationDto createCargoOperationDto)
        {
            var cargoOperation = _mapper.Map<CargoOperation>(createCargoOperationDto);
            _context.Set<CargoOperation>().Add(cargoOperation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCargoOperationAsync(string id)
        {
            var cargoOperation = await _context.Set<CargoOperation>().FindAsync(id);
            if (cargoOperation == null)
            {
                throw new Exception("Cargo company not found");
            }
            _context.Set<CargoOperation>().Remove(cargoOperation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultCargoOperationDto>> GetAllCargoOperationsAsync()
        {
            var result = await _context.Set<CargoOperation>().ToListAsync();
            var cargoOperations = _mapper.Map<List<ResultCargoOperationDto>>(result);
            return cargoOperations;
        }

        public async Task<GetByIdCargoOperationDto> GetByIdCargoOperationAsync(string id)
        {
            var cargoOperation = await _context.Set<CargoOperation>().FindAsync(id);
            var result = _mapper.Map<GetByIdCargoOperationDto>(cargoOperation);
            return result;
        }

        public async Task UpdateCargoOperationAsync(UpdateCargoOperationDto updateCargoOperationDto)
        {
            var cargoOperation = _mapper.Map<CargoOperation>(updateCargoOperationDto);
            _context.Set<CargoOperation>().Update(cargoOperation);
            await _context.SaveChangesAsync();
        }
    }
}
