
using CarBook.Application.Features.Mediator.Results.BlogsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Blogs.Mediator.Queries.BlogQueries
{
    public class GetBlogByIdQuery : IRequest<GetBlogsByIdQueryResults>
    {
        public int Id { get; set; }

        public GetBlogByIdQuery(int id)
        {
            Id = id;
        }
    }
}
