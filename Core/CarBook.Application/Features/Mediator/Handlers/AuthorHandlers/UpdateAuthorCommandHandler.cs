﻿
using CarBook.Application.Features.Mediator.Commands.AuthorCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Authors.Mediator.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler: IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IRepository<Author> _repository;

        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.AuthorId);
            values.Name = request.Name;
            values.Description = request.Description;
           values.İmageUrl=request.İmageUrl;

            await _repository.UpdateAsync(values);
        }
    }
}
