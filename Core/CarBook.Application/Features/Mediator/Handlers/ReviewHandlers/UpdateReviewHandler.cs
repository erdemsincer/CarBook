using CarBook.Application.Features.Mediator.Commands.ReviewCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand>
	{
		private readonly IRepository<Review> _repository;

		public UpdateReviewHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.ReviewId);
			values.CustomerName = request.CustomerName;
			values.CustomerImage = request.CustomerImage;
			values.Comment = request.Comment;
			values.RaytingValue = request.RaytingValue;
			values.ReviewDate = request.ReviewDate;
			values.CarId = request.CarId;
			await _repository.UpdateAsync(values);


		}
	}
}
