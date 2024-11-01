using MediatR;
using MicroserviceECommerce.Application.Interfaces;
using MicroserviceECommerce.Domain.Entities;
using MicroserviceECommerce.Order.Application.Mediator.Queries.AddressQueries;
using MicroserviceECommerce.Order.Application.Mediator.Results.AddressResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceECommerce.Order.Application.Mediator.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, GetAddressByIdQueryResult>
    {
        private readonly IRepositoryBase<Address> _repositoryBase;

        public GetAddressByIdQueryHandler(IRepositoryBase<Address> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repositoryBase.GetByIdAsync(request.Id);

            return new GetAddressByIdQueryResult
            {
                Id = result.Id,
                UserId = result.UserId,
                Name = result.Name,
                Surname = result.Surname,
                Email = result.Email,
                Phone = result.Phone,
                Country = result.Country,
                District = result.District,
                City = result.City,
                Detail1 = result.Detail1,
                Detail2 = result.Detail2,
                Description = result.Description,
                ZipCode = result.ZipCode
            };
        }
    }
}
