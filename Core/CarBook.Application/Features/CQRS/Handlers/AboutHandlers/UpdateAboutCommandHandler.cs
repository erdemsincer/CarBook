using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommands commands)
        {
            var values=await _repository.GetByIdAsync(commands.AboutId);
            values.Description=commands.Description;
            values.Title=commands.Title;
            values.ImageUrl=commands.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
