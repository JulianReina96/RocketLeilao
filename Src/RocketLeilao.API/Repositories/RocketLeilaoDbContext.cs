using Microsoft.EntityFrameworkCore;
using RocketLeilao.API.Entities;

namespace RocketLeilao.API.Repositories
{
    public class RocketLeilaoDbContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\Luísa\Downloads\leilaoDbNLW.db");
        }
    }
}
