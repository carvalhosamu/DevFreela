using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateCommentProject
{
    public class CreateCommentCommand : IRequest
    {
        public CreateCommentCommand(string description, int idUser, int idProject)
        {
            Description = description;
            IdUser = idUser;
            IdProject = idProject;
        }

        public string Description { get; private set; }
        public int IdProject { get; private set; }
        public int IdUser { get; private set; }
    }
}
