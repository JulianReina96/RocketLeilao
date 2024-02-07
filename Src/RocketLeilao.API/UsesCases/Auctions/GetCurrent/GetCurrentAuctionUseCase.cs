using Microsoft.EntityFrameworkCore;
using RocketLeilao.API.Entities;
using RocketLeilao.API.Repositories;

namespace RocketLeilao.API.UsesCases.Auctions.GetCurrent
{
	public class GetCurrentAuctionUseCase
	{
		public Auction? Execute()
		{
			var repository = new RocketLeilaoDbContext();
			var date = DateTime.Now;
			return repository
				.Auctions
				.Include(auction => auction.Items)				
				.FirstOrDefault(auction => auction.Starts <= date && auction.Ends >= date);

		}
	}
}
