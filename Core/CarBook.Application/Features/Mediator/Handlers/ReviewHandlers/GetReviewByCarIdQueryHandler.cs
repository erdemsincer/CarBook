using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
	{
		private readonly IReviewRepository _reviewRepository;

		public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values=_reviewRepository.GetReviewsByCarId(request.Id);
			return values.Select(x=>new GetReviewByCarIdQueryResult
			{
				CarId = x.CarId,
				Comment = x.Comment,
				ReviewDate=x.ReviewDate,
				CustomerImage= x.CustomerImage,	
				CustomerName= x.CustomerName,
				RaytingValue=x.RaytingValue,
				ReviewId = x.ReviewId
			}).ToList();
		}
	}
	
}
