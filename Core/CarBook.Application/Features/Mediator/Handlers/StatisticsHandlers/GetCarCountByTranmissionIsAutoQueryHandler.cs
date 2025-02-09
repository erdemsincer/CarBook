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
    public class GetCarCountByTranmissionIsAutoQueryHandler : IRequestHandler<GetCarCountByTranmissionIsAutoQuery, GetCarCountByTranmissionIsAutoQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetCarCountByTranmissionIsAutoQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetCarCountByTranmissionIsAutoQueryResult> Handle(GetCarCountByTranmissionIsAutoQuery request, CancellationToken cancellationToken)
        {
            var values= _statisticsRepository.GetCarCountByTranmissionIsAuto();
            return new GetCarCountByTranmissionIsAutoQueryResult
            {
                CarCountByTranmissionIsAuto = values,

            };
        }
    }
}
