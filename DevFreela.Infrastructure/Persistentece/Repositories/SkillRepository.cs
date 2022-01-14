using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistentece.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        private readonly string _connectionString;


        public SkillRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            /*using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string sql = "SELECT Id, Description FROM Skills";
                var skills = await sqlConnection.QueryAsync<SkillViewModel>(sql);
                return skills.ToList();
            }*/


            var result =  await _dbContext.Skills
                .ToListAsync();

            return result;
        }
    }
}
