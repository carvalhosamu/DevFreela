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
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddUserAsync(User user)
        {
            var result = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var result = await _dbContext.Users
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var result = await _dbContext.Users
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
