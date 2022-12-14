using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Context
{
    public class DiamondContext : DbContext
    {
        public DiamondContext(DbContextOptions<DiamondContext> options) : base(options)
        {

        }
        public DbSet<Diamond> Diamonds { get; set; }
        public DbSet<Retailer> Retailers { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}