using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webApi.Models;

namespace webApi.Contexts
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> ctx):base(ctx)
        {
            
        }

        public DbSet<User> users {get; set;}

    }
}