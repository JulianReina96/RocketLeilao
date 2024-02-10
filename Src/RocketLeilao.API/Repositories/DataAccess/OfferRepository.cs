using RocketLeilao.API.Contracts;
using RocketLeilao.API.Entities;

namespace RocketLeilao.API.Repositories.DataAccess
{
	public class OfferRepository : IOfferRepository
	{
		private readonly RocketLeilaoDbContext _dbcontext;

		public OfferRepository(RocketLeilaoDbContext dbContext) => _dbcontext = dbContext;

		public void Add(Offer offer)
		{
			_dbcontext.Offers.Add(offer);

			_dbcontext.SaveChanges();
		}
	}
}
