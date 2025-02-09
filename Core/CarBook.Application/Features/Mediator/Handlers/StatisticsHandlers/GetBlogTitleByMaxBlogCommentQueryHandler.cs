using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBlogTitleByMaxBlogCommentQueryHandler : IRequestHandler<GetBlogTitleByMaxBlogCommentQuery, GetBlogTitleByMaxBlogCommentQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetBlogTitleByMaxBlogCommentQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetBlogTitleByMaxBlogCommentQueryResult> Handle(GetBlogTitleByMaxBlogCommentQuery request, CancellationToken cancellationToken)
        {
            var values = _statisticsRepository.GetBlogTitleByMaxBlogComment();
            return new GetBlogTitleByMaxBlogCommentQueryResult
            {
                BlogTitleByMaxBlogComment = values,

            };
        }
    }
}
