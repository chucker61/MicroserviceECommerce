using MediatR;
using MicroserviceECommerce.Application.Interfaces;
using MicroserviceECommerce.Domain.Entities;
using MicroserviceECommerce.Order.Application.Mediator.Commands.OrderingCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceECommerce.Order.Application.Mediator.Handlers.OrderingHandlers
{
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
    {
        private readonly IRepositoryBase<Ordering> _repository;
        public RemoveOrderingCommandHandler(IRepositoryBase<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
