﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest
    {
        public UpdateProjectCommand(int id, string title, string description, decimal totalCost)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }

        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
    }
}