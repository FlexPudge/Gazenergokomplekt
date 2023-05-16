using Gazenergokomplekt.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace Gazenergokomplekt.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Admins>? Admins { get; set; }
        public DbSet<Orders>? Orders { get; set; }
    }
}
