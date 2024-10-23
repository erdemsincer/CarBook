using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResults>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResults> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.Id);
            return new GetPricingByIdQueryResults
            {
                Name = values.Name,
                PricingId = values.PricingId,

            };
        }
    }
}
