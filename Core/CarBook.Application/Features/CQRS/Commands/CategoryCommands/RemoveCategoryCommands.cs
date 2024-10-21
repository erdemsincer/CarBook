using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveCategoryCommands
    {
        public int Id { get; set; }

        public RemoveCategoryCommands(int id)
        {
            Id = id;
        }
    }
}
