﻿using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResults>
    {
        private readonly IRepository<Location> _repository;

        public GetBlogByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResults> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.Id);
            return new GetLocationByIdQueryResults
            {
                LocationId = values.LocationId,
                Name = values.Name,

            };
        }
    }
}
