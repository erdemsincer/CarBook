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
    public class GetBrandCountQueryHandler: IRequestHandler<GetBrandCountQuery, GetBrandCountQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetBrandCountQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetBrandCountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
        {
            var values = _statisticsRepository.GetBrandCount();
            return new GetBrandCountQueryResult
            {
                BrandCount = values,

            };
        }
    }
}
