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
    public class GetBlogCountQueryHandler: IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetBlogCountQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetBlogCountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
        {
            var values = _statisticsRepository.GetBlogCount();
            return new GetBlogCountQueryResult
            {
                BlogCount = values,

            };
        }
    }
}
