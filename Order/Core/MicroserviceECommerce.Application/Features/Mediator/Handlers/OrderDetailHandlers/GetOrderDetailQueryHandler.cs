using MediatR;
using MicroserviceECommerce.Application.Features.Mediator.Queries.OrderDetailQueries;
using MicroserviceECommerce.Application.Features.Mediator.Results.OrderDetailResults;
using MicroserviceECommerce.Application.Interfaces;
using MicroserviceECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceECommerce.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, List<GetOrderDetailQueryResult>>
    {
        private readonly IRepositoryBase<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepositoryBase<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var orderDetail = await _repository.GetAllAsync();
            return orderDetail.Select(x => new GetOrderDetailQueryResult
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductAmount = x.ProductAmount,
                ProductTotalPrice = x.ProductTotalPrice,
                OrderingId = x.OrderingId,
            }).ToList();
        }
    }
}
