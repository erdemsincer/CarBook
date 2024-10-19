using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommands commands)
        {
            var values=await _repository.GetByIdAsync(commands.BannerId);
            values.Title = commands.Title;
            values.Description = commands.Description;
            values.VideoDescription = commands.VideoDescription;
            values.VideoUrl = commands.VideoUrl;
            await _repository.UpdateAsync(values);

        }
    }
}
