using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<GetContactQueryResults> Handle(GetContactByIdQuery commands)
        {
            var values=await _repository.GetByIdAsync(commands.Id);
            return new GetContactQueryResults
            {
                ContactId = values.ContactId,
                Email = values.Email,
                SendDate = values.SendDate,
                Subject = values.Subject,
                Message = values.Message,
                Name = values.Name,

            };
        }
    }
}
