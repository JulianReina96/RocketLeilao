using RocketLeilao.API.Entities;

namespace RocketLeilao.API.Contracts
{
	public interface IAuctionRepository
	{
		Auction? GetCurrent();
	}
}
