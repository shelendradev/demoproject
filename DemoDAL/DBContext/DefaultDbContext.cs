using DemoDAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace DemoDAL.DBContext
{
    public class DefaultDbContext(DbContextOptions<DefaultDbContext> dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<UserModel> UserModels { get; set; }

    }
}
