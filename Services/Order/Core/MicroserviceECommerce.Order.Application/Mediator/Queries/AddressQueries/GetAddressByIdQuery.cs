﻿using MediatR;
using MicroserviceECommerce.Order.Application.Mediator.Results.AddressResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceECommerce.Order.Application.Mediator.Queries.AddressQueries
{
    public class GetAddressByIdQuery : IRequest<GetAddressByIdQueryResult>
    {
        public int Id { get; set; }

        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
