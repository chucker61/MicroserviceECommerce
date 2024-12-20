﻿using MediatR;
using MicroserviceECommerce.Application.Interfaces;
using MicroserviceECommerce.Domain.Entities;
using MicroserviceECommerce.Order.Application.Mediator.Queries.OrderingQueries;
using MicroserviceECommerce.Order.Application.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceECommerce.Order.Application.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        private readonly IRepositoryBase<Ordering> _repository;

        public GetOrderingQueryHandler(IRepositoryBase<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderingQueryResult
            {
                Id = x.Id,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId
            }).ToList();
        }
    }
}
