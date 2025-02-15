using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _carFeatureRepository.GetCarFeaturesByCarID(request.Id);
            return values.Select(x => new GetCarFeatureByCarIdQueryResult
            {
                CarFeatureID = x.CarFeatureId,
                FeatureID = x.FeatureId,
                FeatureName = x.Feature.Name,
                Available = x.Available
            }).ToList();
        }
    }
}
