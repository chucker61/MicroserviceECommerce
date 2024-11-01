using MediatR;
using MicroserviceECommerce.Application.Interfaces;
using MicroserviceECommerce.Domain.Entities;
using MicroserviceECommerce.Order.Application.Mediator.Queries.OrderDetailQueries;
using MicroserviceECommerce.Order.Application.Mediator.Results.OrderDetailResults;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceECommerce.Order.Application.Mediator.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdQueryResult>
    {
        private readonly IRepositoryBase<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepositoryBase<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var orderDetail = await _repository.GetByIdAsync(request.Id);
            return new GetOrderDetailByIdQueryResult
            {
                Id = orderDetail.Id,
                ProductId = orderDetail.ProductId,
                ProductName = orderDetail.ProductName,
                ProductPrice = orderDetail.ProductPrice,
                ProductAmount = orderDetail.ProductAmount,
                ProductTotalPrice = orderDetail.ProductTotalPrice,
                OrderingId = orderDetail.OrderingId,
            };
        }
    }
}
