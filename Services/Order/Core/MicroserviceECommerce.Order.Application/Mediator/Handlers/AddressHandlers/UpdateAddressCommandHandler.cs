using MediatR;
using MicroserviceECommerce.Application.Interfaces;
using MicroserviceECommerce.Domain.Entities;
using MicroserviceECommerce.Order.Application.Mediator.Commands.AddressCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceECommerce.Order.Application.Mediator.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IRepositoryBase<Address> _repositoryBase;

        public UpdateAddressCommandHandler(IRepositoryBase<Address> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var result = await _repositoryBase.GetByIdAsync(request.Id);
            result.Id = request.Id;
            result.UserId = request.UserId;
            result.Name = request.Name;
            result.Surname = request.Surname;
            result.Email = request.Email;
            result.Phone = request.Phone;
            result.Country = request.Country;
            result.District = request.District;
            result.City = request.City;
            result.Detail1 = request.Detail1;
            result.Detail2 = request.Detail2;
            result.Description = request.Description;
            result.ZipCode = request.ZipCode;

            await _repositoryBase.UpdateAsync(result);
        }
    }
}
