using Microsoft.EntityFrameworkCore;
using RocketLeilao.API.Entities;

namespace RocketLeilao.API.Repositories
{
    public class RocketLeilaoDbContext : DbContext
    {
        public RocketLeilaoDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }

    }
}
