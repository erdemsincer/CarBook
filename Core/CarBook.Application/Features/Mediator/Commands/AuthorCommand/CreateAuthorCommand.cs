using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.AuthorCommand
{
    public class CreateAuthorCommand:IRequest
    {
       
        public string Name { get; set; }
        public string İmageUrl { get; set; }
        public string Description { get; set; }
    }
}
