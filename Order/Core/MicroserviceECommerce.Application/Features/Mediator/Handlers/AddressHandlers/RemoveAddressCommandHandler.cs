﻿using MediatR;
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
    public class RemoveAddressCommandHandler : IRequestHandler<RemoveAddressCommand>
    {
        private readonly IRepositoryBase<Address> _repositoryBase;

        public RemoveAddressCommandHandler(IRepositoryBase<Address> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        public async Task Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
        {
            var result = await _repositoryBase.GetByIdAsync(request.Id);
            await _repositoryBase.DeleteAsync(result);
        }
    }
}
