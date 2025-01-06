using CarBook.Application.Blogs.Mediator.Queries.BlogQueries;
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
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogsByIdQueryResults>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogsByIdQueryResults> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.Id);
            return new GetBlogsByIdQueryResults
            {
            CreateDate = values.CreateDate,
            Title = values.Title,
            AuthorId = values.AuthorId,
            BlogId = values.BlogId,
            CategoryId = values.CategoryId,
           
            Description=values.Description,


             CoverImageUrl = values.CoverImageUrl,

            };
        }
    }
}
