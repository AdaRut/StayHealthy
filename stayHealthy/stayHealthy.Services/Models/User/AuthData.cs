using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Models.User
{
    public class AuthData
    {
        public string Token { get; set; }
        public User User { get; set; }
    }
}
