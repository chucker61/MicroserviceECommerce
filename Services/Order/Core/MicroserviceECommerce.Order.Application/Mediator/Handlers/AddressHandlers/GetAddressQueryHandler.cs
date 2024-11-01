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
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, List<GetAddressQueryResult>>
    {
        private readonly IRepositoryBase<Address> _repositoryBase;

        public GetAddressQueryHandler(IRepositoryBase<Address> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<List<GetAddressQueryResult>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var result = await _repositoryBase.GetAllAsync();
            return result.Select(x => new GetAddressQueryResult
            {
                Id = x.Id,
                UserId = x.UserId,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Phone = x.Phone,
                Country = x.Country,
                District = x.District,
                City = x.City,
                Detail1 = x.Detail1,
                Detail2 = x.Detail2,
                Description = x.Description,
                ZipCode = x.ZipCode
            }).ToList();
        }
    }
}
