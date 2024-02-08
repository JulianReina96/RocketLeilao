
using Microsoft.AspNetCore.Mvc;
using RocketLeilao.API.Comunications.Request.Response;
using RocketLeilao.API.Filtros;
using RocketLeilao.API.UsesCases.Offers.CreateOffer;

namespace RocketLeilao.API.Controllers
{

    public class OfferController : RocketAuctionBaseController
    {
        [HttpPost]
        [Route("{itemId}")]
        [ServiceFilter(typeof(AuthenticationUserAttribute))]
        public IActionResult CreateOffer(
            [FromRoute] int itemId, 
            [FromBody]RequestCreatedOfferJson request,
            [FromServices] CreateOfferUseCase useCase
            )
        {
            var id = useCase.Execute(itemId, request);
            return Created(string.Empty, id );
        }
    }
}
