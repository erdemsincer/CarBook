using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CommentCommand
{
    public class CreateCommentCommand:IRequest
    {
        public string Name { get; set; }
        public int BlogId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
    }
}
