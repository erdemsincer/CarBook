using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		public Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
	
}
