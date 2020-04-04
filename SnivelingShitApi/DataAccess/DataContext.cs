using Microsoft.EntityFrameworkCore;
using SnivelingShitApi.DataAccess.Entities;

namespace SnivelingShitApi.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> contextOptions) : base(contextOptions)
        {
        }


        public virtual DbSet<Film> Films { get; set; }
    }
}