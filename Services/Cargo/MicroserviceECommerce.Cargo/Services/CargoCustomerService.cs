using AutoMapper;
using MicroserviceECommerce.Cargo.Context;
using MicroserviceECommerce.Cargo.Entities.Dtos.CargoCustomerDtos;
using MicroserviceECommerce.Cargo.Entities.Models;
using MicroserviceECommerce.Cargo.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.Cargo.Services
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CargoCustomerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCargoCustomerAsync(CreateCargoCustomerDto createCargoCustomerDto)
        {
            var cargoCustomer = _mapper.Map<CargoCustomer>(createCargoCustomerDto);
            _context.Set<CargoCustomer>().Add(cargoCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCargoCustomerAsync(string id)
        {
            var cargoCustomer = await _context.Set<CargoCustomer>().FindAsync(id);
            if (cargoCustomer == null)
            {
                throw new Exception("Cargo company not found");
            }
            _context.Set<CargoCustomer>().Remove(cargoCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultCargoCustomerDto>> GetAllCargoCustomersAsync()
        {
            var result = await _context.Set<CargoCustomer>().ToListAsync();
            var cargoCustomers = _mapper.Map<List<ResultCargoCustomerDto>>(result);
            return cargoCustomers;
        }

        public async Task<GetByIdCargoCustomerDto> GetByIdCargoCustomerAsync(string id)
        {
            var cargoCustomer = await _context.Set<CargoCustomer>().FindAsync(id);
            var result = _mapper.Map<GetByIdCargoCustomerDto>(cargoCustomer);
            return result;
        }

        public async Task UpdateCargoCustomerAsync(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            var cargoCustomer = _mapper.Map<CargoCustomer>(updateCargoCustomerDto);
            _context.Set<CargoCustomer>().Update(cargoCustomer);
            await _context.SaveChangesAsync();
        }
    }
}
