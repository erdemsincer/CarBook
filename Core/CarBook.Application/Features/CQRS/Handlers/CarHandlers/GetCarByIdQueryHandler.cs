using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarQueryResults> Handle(GetCarByIdQuery commands)
        {
            var values = await _repository.GetByIdAsync(commands.Id);
            return new GetCarQueryResults
            {
                BigImageUrl = values.BigImageUrl,
                BrandId = values.BrandId,
                CarId = values.CarId,
                CoverImageUrl = values.CoverImageUrl,
                Fuel=values.Fuel,
                Km=values.Km,
                Luggage=values.Luggage,
                Model=values.Model,
                Seat=values.Seat,
                Transmission=values.Transmission,

            };

        }
    }
}

