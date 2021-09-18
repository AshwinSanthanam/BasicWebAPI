using BasicWebApi.DataAccess.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebApi.DataAccess
{
    public class BasicWebAPIDbContext : DbContext
    {
        public BasicWebAPIDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
