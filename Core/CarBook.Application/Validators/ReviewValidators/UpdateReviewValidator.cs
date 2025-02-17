using CarBook.Application.Features.Mediator.Commands.ReviewCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
	public class UpdateReviewValidator:AbstractValidator<UpdateReviewCommand>
	{
        public UpdateReviewValidator()
        {
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyin");
			RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Müşteri adı en az 5 karakter olmalıdır");
			RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Lütfen puanlama yapınız");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorum yapınız");
		}
    }
}
