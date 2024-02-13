using BarinakAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Persistence
{
    public class DesignTimeDbContextFactory:IDesignTimeDbContextFactory<BarinakAPIDBContext>
    {
        public BarinakAPIDBContext CreateDbContext(string[] args)
        {

            DbContextOptionsBuilder<BarinakAPIDBContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConfigrationString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
