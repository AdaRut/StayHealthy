using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Interfaces.Utils
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(int userId, string userRole);
    }
}
