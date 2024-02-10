using Bogus;
using FluentAssertions;
using Moq;
using RocketLeilao.API.Contracts;
using RocketLeilao.API.Entities;
using RocketLeilao.API.Enums;
using RocketLeilao.API.UsesCases.Auctions.GetCurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent
{
	public class GetCurrentAuctionUseCaseTest
	{
		[Fact]
		public void Success()
		{

			//ARRANGE
			//Inicializar todo o necessario:

			//Usar Biblioteca para criar uma entidade falsa de acordo com as regras estabelecidas

			var entity = new Faker<Auction>().RuleFor(auction => auction.Id, faker => faker.Random.Number(1, 200))
				.RuleFor(auction => auction.Name, f => f.Lorem.Word())
				.RuleFor(auction => auction.Starts, f => f.Date.Past())
				.RuleFor(auction => auction.Ends, f => f.Date.Past())
				.RuleFor(auction => auction.Items, (f, auction) => new List<Item>
				{
					new Item
					{
						Id = f.Random.Number(1, 405),
						Name = f.Commerce.ProductName(),
						Brand = f.Commerce.Department(),
						BasePrice = f.Random.Decimal(50, 1000),
						Condition = f.PickRandom<Condition>(),
						AuctionId = auction.Id
					}
				}).Generate();
				
				

			//gera um 'fake' repository. Usado apenas com interface pois cria uma implementacao da mesma
			var mock = new Mock<IAuctionRepository>();

			//define o valor de retorno: Quando alguem chamar a funcao getcurrent o mock vai retornar algo(leilao)
			mock.Setup(i=>  i.GetCurrent()).Returns( new Auction());



	
			var useCase = new GetCurrentAuctionUseCase(mock.Object);

			//ACT
			//Utilizar as instancias
		    var auction = useCase.Execute();


			//ASSERT
			//Testar os resultados

			//uso sem nupackage
			//Assert.NotNull(auction);
			// uso com package
			auction.Should().NotBeNull();

			auction.Id.Should().Be(entity.Id);
			auction.Name.Should().Be(entity.Name);

		}
	}
}
