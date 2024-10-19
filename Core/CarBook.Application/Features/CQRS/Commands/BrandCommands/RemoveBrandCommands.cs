using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.BrandCommands
{
    public class RemoveBrandCommands
    {
        public int Id { get; set; }

        public RemoveBrandCommands(int id)
        {
            Id = id;
        }
    }
}
