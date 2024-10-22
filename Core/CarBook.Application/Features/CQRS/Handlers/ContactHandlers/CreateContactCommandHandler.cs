using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactCommands commands)
        {
            await _repository.CreateAsync(new Contact
            {
                Name = commands.Name,
                SendDate = commands.SendDate,
                Email = commands.Email,
                Message = commands.Message,
                Subject = commands.Subject,
                

            });
        }
    }
}
