using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Service
{
    public interface IAuthService
    {
        public string GenerateToken(string email, string role);
        public string ComputSha256Hash(string password);
    }
}
