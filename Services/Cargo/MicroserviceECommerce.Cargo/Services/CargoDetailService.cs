using AutoMapper;
using MicroserviceECommerce.Cargo.Context;
using MicroserviceECommerce.Cargo.Entities.Dtos.CargoDetailDtos;
using MicroserviceECommerce.Cargo.Entities.Models;
using MicroserviceECommerce.Cargo.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.Cargo.Services
{
    public class CargoDetailService : ICargoDetailService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CargoDetailService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto)
        {
            var cargoDetail = _mapper.Map<CargoDetail>(createCargoDetailDto);
            _context.Set<CargoDetail>().Add(cargoDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCargoDetailAsync(string id)
        {
            var cargoDetail = await _context.Set<CargoDetail>().FindAsync(id);
            if (cargoDetail == null)
            {
                throw new Exception("Cargo company not found");
            }
            _context.Set<CargoDetail>().Remove(cargoDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultCargoDetailDto>> GetAllCargoDetailsAsync()
        {
            var result = await _context.Set<CargoDetail>().ToListAsync();
            var cargoDetails = _mapper.Map<List<ResultCargoDetailDto>>(result);
            return cargoDetails;
        }

        public async Task<GetByIdCargoDetailDto> GetByIdCargoDetailAsync(string id)
        {
            var cargoDetail = await _context.Set<CargoDetail>().FindAsync(id);
            var result = _mapper.Map<GetByIdCargoDetailDto>(cargoDetail);
            return result;
        }

        public async Task UpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto)
        {
            var cargoDetail = _mapper.Map<CargoDetail>(updateCargoDetailDto);
            _context.Set<CargoDetail>().Update(cargoDetail);
            await _context.SaveChangesAsync();
        }
    }
}
