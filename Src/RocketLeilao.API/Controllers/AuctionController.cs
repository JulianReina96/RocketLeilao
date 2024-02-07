﻿using Microsoft.AspNetCore.Mvc;
using RocketLeilao.API.Entities;
using RocketLeilao.API.UsesCases.Auctions.GetCurrent;

namespace RocketLeilao.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuctionController : ControllerBase
	{
		[HttpGet]
		[ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult GetCurrentAuction()
		{
			var useCase = new GetCurrentAuctionUseCase();
			var result = useCase.Execute();
			if (result is null)
				return NoContent();
			return Ok(result);
		}
	}
}
