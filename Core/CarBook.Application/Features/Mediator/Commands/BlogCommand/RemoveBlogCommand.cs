using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommand
{
    public class RemoveBlogCommand: IRequest
    {
        public int Id { get; set; }

        public RemoveBlogCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
