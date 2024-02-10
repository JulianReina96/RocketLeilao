using RocketLeilao.API.Entities;

namespace RocketLeilao.API.Contracts
{
	public interface IOfferRepository
	{
		public void Add(Offer offer);
	}
}
