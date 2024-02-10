using RocketLeilao.API.Comunications.Request.Response;
using RocketLeilao.API.Contracts;
using RocketLeilao.API.Entities;
using RocketLeilao.API.Repositories;
using RocketLeilao.API.Services;

namespace RocketLeilao.API.UsesCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly ILoggedUser _loggerUser;
        private readonly IOfferRepository _repository;

        public CreateOfferUseCase(ILoggedUser loggerUser, IOfferRepository repository)
        {
			_loggerUser = loggerUser;
            _repository = repository;
		}

        public int Execute(int itemId, RequestCreatedOfferJson request)
        {
            var user = _loggerUser.User();
            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id

            };
            _repository.Add(offer);


            return offer.Id;
        }
    }
}
