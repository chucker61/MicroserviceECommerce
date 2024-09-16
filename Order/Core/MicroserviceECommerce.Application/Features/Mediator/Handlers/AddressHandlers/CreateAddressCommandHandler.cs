using MediatR;
using MicroserviceECommerce.Application.Features.Mediator.Commands.AddressCommands;
using MicroserviceECommerce.Application.Interfaces;
using MicroserviceECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceECommerce.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand>
    {
        private readonly IRepositoryBase<Address> _repository;

        public CreateAddressCommandHandler(IRepositoryBase<Address> repository)
        {
            _repository = repository;
        }


        public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new Address
            {
                UserId = request.UserId,
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Phone = request.Phone,
                Country = request.Country,
                District = request.District,
                City = request.City,
                Detail1 = request.Detail1,
                Detail2 = request.Detail2,
                Description = request.Description,
                ZipCode = request.ZipCode
            });
        }
    }
}
