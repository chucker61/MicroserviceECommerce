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
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand>
    {
        private readonly IRepositoryBase<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepositoryBase<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = await _repository.GetByIdAsync(request.Id);

            orderDetail.ProductId = request.ProductId;
            orderDetail.ProductName = request.ProductName;
            orderDetail.ProductPrice = request.ProductPrice;
            orderDetail.ProductAmount = request.ProductAmount;
            orderDetail.ProductTotalPrice = request.ProductTotalPrice;
            orderDetail.OrderingId = request.OrderingId;

            await _repository.UpdateAsync(orderDetail);
        }
    }
}
