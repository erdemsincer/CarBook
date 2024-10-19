using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<GetBannerQueryResults> Handle(GetBannerByIdQuery commands)
        {
            var values= await _repository.GetByIdAsync(commands.Id);
            return new GetBannerQueryResults
            {
                BannerId = values.BannerId,
                Description = values.Description,
                Title = values.Title,
                VideoDescription = values.VideoDescription,
                VideoUrl = values.VideoUrl,
            };
        }

       
    }
}
