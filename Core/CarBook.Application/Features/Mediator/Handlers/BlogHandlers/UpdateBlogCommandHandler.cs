using CarBook.Application.Features.Mediator.Commands.BlogCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.BlogId);
            
            values.CreateDate=request.CreateDate;
            values.CategoryId=request.CategoryId;
            values.AuthorId=request.AuthorId;
            values.CoverImageUrl=request.CoverImageUrl;
            values.Title=request.Title;
            
            await _repository.UpdateAsync(values);
            
        }
    }
}
