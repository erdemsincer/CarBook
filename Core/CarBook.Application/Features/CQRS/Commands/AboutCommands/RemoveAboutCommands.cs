using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.AboutCommands
{
    public class RemoveAboutCommands
    {
        public int Id { get; set; }

        public RemoveAboutCommands(int id)
        {
            Id = id;
        }

    }
}
