﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceECommerce.Application.Features.Mediator.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveOrderDetailCommand(int id)
        {
            Id = id;
        }
    }
}
