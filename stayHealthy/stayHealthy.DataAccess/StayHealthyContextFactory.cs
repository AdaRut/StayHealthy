using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.DataAccess
{
    class StayHealthyContextFactory : IDesignTimeDbContextFactory<StayHealthyContext>
    {
        public StayHealthyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StayHealthyContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StayHealthyDb;Trusted_Connection=True;");
            return new StayHealthyContext(optionsBuilder.Options);
        }
    }
}
