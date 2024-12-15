using CarBook.Application.Features.Mediator.Queries.BlogQueries;

using CarBook.Application.Features.Mediator.Results.BlogsResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogsQueryResult>>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogsQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetBlogsQueryResult
            {
                BlogId = x.BlogId,
                AuthorId = x.AuthorId,
                CategoryId = x.CategoryId,
                CreateDate = x.CreateDate,
                CoverImageUrl = x.CoverImageUrl,
                Title = x.Title,
            }).ToList();
        }
    }
}
