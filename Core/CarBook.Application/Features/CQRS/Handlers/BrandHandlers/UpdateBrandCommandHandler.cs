using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBrandCommands commands)
        {
            var values = await _repository.GetByIdAsync(commands.BrandId);
            values.Name = commands.Name;
            await _repository.UpdateAsync(values);

        }
    }
}
