using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.StartProject
{
    internal class StartProjectCommandHandler : IRequestHandler<StartProjectCommand>
    {
        private readonly IProjectRepository _repository;

        public StartProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var project = await _repository.GetByIdAsync(request.Id);

                if (project == null)
                {
                    throw new ArgumentException("O Id Informado não existe", nameof(request.Id));

                }

                project.Start();
                await _repository.SaveChangesAsync();
                return Unit.Value;
            }
            catch (Exception)
            {

                throw;
            }
            
           
        }
    }
}
