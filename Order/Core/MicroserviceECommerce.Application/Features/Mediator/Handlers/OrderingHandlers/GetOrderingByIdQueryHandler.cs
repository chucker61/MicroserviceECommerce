using MediatR;
using MicroserviceECommerce.Application.Features.Mediator.Queries.OrderingQueries;
using MicroserviceECommerce.Application.Features.Mediator.Results.OrderingResults;
using MicroserviceECommerce.Application.Interfaces;
using MicroserviceECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceECommerce.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepositoryBase<Ordering> _repository;
        public GetOrderingByIdQueryHandler(IRepositoryBase<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult
            {
                OrderDate = values.OrderDate,
                Id = values.Id,
                TotalPrice = values.TotalPrice,
                UserId = values.UserId
            };
        }
    }
}
