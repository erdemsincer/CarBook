using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommands commands)
        {
            await _repository.CreateAsync(new Car
            {
                BigImageUrl=commands.BigImageUrl,
                Km=commands.Km,
                Fuel=commands.Fuel,
                Seat=commands.Seat,
                Luggage=commands.Luggage,
                Model=commands.Model,
                Transmission=commands.Transmission,
                CoverImageUrl=commands.CoverImageUrl,
                BrandId=commands.BrandId,
                

            });
        }
    }
}
