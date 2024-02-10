using Microsoft.EntityFrameworkCore;
using RocketLeilao.API.Contracts;
using RocketLeilao.API.Entities;
using RocketLeilao.API.Repositories;

namespace RocketLeilao.API.UsesCases.Auctions.GetCurrent
{
	public class GetCurrentAuctionUseCase
	{
		private readonly IAuctionRepository _repository;

		public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;


		public Auction? Execute() => _repository.GetCurrent();

	}
}
