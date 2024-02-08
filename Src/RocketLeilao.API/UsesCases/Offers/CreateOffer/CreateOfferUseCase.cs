using RocketLeilao.API.Comunications.Request.Response;
using RocketLeilao.API.Entities;
using RocketLeilao.API.Repositories;
using RocketLeilao.API.Services;

namespace RocketLeilao.API.UsesCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly LoggerUser _loggerUser;

        public CreateOfferUseCase(LoggerUser loggerUser) => _loggerUser = loggerUser;

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
            var repository = new RocketLeilaoDbContext();
            repository.Offers.Add(offer);

            repository.SaveChanges();

            return offer.Id;
        }
    }
}
