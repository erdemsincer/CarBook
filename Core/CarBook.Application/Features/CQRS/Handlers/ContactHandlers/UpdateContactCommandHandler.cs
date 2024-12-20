﻿using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommands command)
        {
            var values=await _repository.GetByIdAsync(command.ContactId);
            values.Email=command.Email;
            values.SendDate=command.SendDate;
            values.Subject=command.Subject;
            values.Message=command.Message;
            values.Name=command.Name;
            values.ContactId=command.ContactId;
            await _repository.UpdateAsync(values);
        }
    }
}
