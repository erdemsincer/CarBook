﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommand
{
    public class UpdateCarFeatureAvailableChangeToTrueCommand:IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeatureAvailableChangeToTrueCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
