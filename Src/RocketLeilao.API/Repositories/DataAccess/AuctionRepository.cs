using Microsoft.EntityFrameworkCore;
using RocketLeilao.API.Contracts;
using RocketLeilao.API.Entities;

namespace RocketLeilao.API.Repositories.DataAccess
{
	public class AuctionRepository : IAuctionRepository
	{
		private readonly RocketLeilaoDbContext _dbcontext;

		public AuctionRepository(RocketLeilaoDbContext dbContext) => _dbcontext = dbContext;

		public Auction? GetCurrent()
		{
			var date = DateTime.Now;
			return _dbcontext
				.Auctions
				.Include(auction => auction.Items)
				.FirstOrDefault(auction => auction.Starts <= date && auction.Ends >= date);


		}
	}
}
