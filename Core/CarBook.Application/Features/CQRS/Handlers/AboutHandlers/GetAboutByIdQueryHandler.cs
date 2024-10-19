using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResults> Handle(GetAboutByIdQuery query)
        {
            var values= await _repository.GetByIdAsync(query.Id);
            return new GetAboutByIdQueryResults
            {
                AboutId = values.AboutId,
                Title = values.Title,
                Description = values.Description,
                ImageUrl = values.ImageUrl

            };

        }
    }
}
