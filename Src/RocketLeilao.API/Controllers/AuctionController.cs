using Microsoft.AspNetCore.Mvc;
using RocketLeilao.API.UsesCases.Auctions.GetCurrent;

namespace RocketLeilao.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuctionController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetCurrentAuction()
		{
			var useCase = new GetCurrentAuctionUseCase();
			var result = useCase.Execute();
			return Ok(result);
		}
	}
}
