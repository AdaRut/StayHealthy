using Microsoft.AspNetCore.Http;
using stayHealthy.Services.Interfaces.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Services.Utils
{
    public class AuthProvider : IAuthProvider
    {
        private readonly IHttpContextAccessor context;

        public AuthProvider(IHttpContextAccessor context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int GetUserId()
        {
            return int.Parse(context.HttpContext.User.Claims
                       .First(i => i.Type == ClaimTypes.NameIdentifier).Value);
        }

        public string GetUserRole()
        {
            return context.HttpContext.User.Claims
                      .First(i => i.Type == ClaimTypes.Role).Value;
        }
    }
}
