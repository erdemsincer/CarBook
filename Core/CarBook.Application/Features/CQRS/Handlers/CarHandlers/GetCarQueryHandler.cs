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
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResults>> Handle()
        {
            var values=await _repository.GetAllAsync();
            return values.Select(x=>new GetCarQueryResults{
                CarId = x.CarId,
                BrandId=x.BrandId,
                BigImageUrl=x.BigImageUrl,
                CoverImageUrl=x.CoverImageUrl,
                Fuel=x.Fuel,
                Km=x.Km,
                Seat=x.Seat,
                Luggage=x.Luggage,
                Transmission=x.Transmission,
                Model=x.Model,
            }).ToList();

        }
    }
}
