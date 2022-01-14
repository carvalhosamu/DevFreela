using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using DevFreela.Application.ViewModels;
using Microsoft.EntityFrameworkCore;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Queries.GetProjectsById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailModel>
    {


        private readonly IProjectRepository _repository;

        public GetProjectByIdQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectDetailModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetByIdAsync(request.Id);

            if (projects != null)
            {
                return new ProjectDetailModel(projects.Id,
                                    projects.Title,
                                    projects.Description,
                                    projects.TotalCost,
                                    projects.CreatedAt,
                                    projects.StartedAt,
                                    projects.Client.FullName,
                                    projects.Freelancer.FullName);
            }

            throw new ArgumentException("Id Não encontrado");
        }
    }
}
