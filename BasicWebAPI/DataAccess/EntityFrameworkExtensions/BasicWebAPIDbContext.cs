using BasicWebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.DataAccess.EntityFrameworkExtensions
{
    public class BasicWebAPIDbContext : DbContext
    {
        public BasicWebAPIDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
