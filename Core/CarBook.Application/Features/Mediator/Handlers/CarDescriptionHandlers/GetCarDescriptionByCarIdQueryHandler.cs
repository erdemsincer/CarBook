using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResult;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
	public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionQueryResult>
	{
		private readonly ICarDescriptionRepository _carDescriptionRepository;

		public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository carDescriptionRepository)
		{
			_carDescriptionRepository = carDescriptionRepository;
		}

		public async Task<GetCarDescriptionQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _carDescriptionRepository.GetCarDescription(request.Id);

			return new GetCarDescriptionQueryResult
			{
				CarDescriptionID = values.CarDescriptionId,
				CarID = values.CarId,
				Details = values.Detail
			};
		}
	}
}
