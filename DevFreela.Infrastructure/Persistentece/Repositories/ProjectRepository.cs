using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistentece.Repositories
{
    public class ProjectRepository : IProjectRepository
    {

        private readonly DevFreelaDbContext _dbContext;

        public ProjectRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Project project)
        {
            var result = await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task AddComentAsync(ProjectComment comment)
        {
            if (await _dbContext.Projects.Where(c => c.Id == comment.IdProject).CountAsync() == 0)
            {
                throw new ArgumentException("Id do Projeto não encontrado", nameof(comment.IdProject));
            }

            await _dbContext.ProjectComments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var project = await _dbContext.Projects
                .Include(c => c.Client)
                .Include(f => f.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id);

            return project;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
