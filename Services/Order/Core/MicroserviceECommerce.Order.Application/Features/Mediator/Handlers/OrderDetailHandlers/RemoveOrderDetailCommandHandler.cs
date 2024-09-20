using MediatR;
using MicroserviceECommerce.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceECommerce.Application.Interfaces;
using MicroserviceECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceECommerce.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler : IRequestHandler<RemoveOrderDetailCommand>
    {
        private readonly IRepositoryBase<OrderDetail> _repository;

        public RemoveOrderDetailCommandHandler(IRepositoryBase<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(orderDetail);
        }
    }
}
