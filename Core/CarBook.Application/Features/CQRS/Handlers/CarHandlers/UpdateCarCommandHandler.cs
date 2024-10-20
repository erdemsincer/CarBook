using CarBook.Application.Features.CQRS.Commands.AboutCommands;
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
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommands commands){
            var values = await _repository.GetByIdAsync(commands.CarId);
            values.Model=commands.Model;
            values.Fuel=commands.Fuel;
            values.Km=commands.Km;
            values.Seat=commands.Seat;
            values.Transmission=commands.Transmission;
            values.Luggage=commands.Luggage;
            values.CoverImageUrl=commands.CoverImageUrl;
            values.BigImageUrl=commands.BigImageUrl;
            values.BrandId=commands.BrandId;

            await _repository.UpdateAsync(values);



    }
    }
}
