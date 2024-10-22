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
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetContactByIdQueryResults>> Handle()
        {
            var values =await _repository.GetAllAsync();
            return values.Select(x => new GetContactByIdQueryResults {
                ContactId = x.ContactId,
                Email = x.Email,
                Message = x.Message,
                SendDate = x.SendDate,
                Name = x.Name,
                Subject = x.Subject,
        }).ToList();
    }
}
}
