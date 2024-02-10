using Bogus;
using FluentAssertions;
using Moq;
using RocketLeilao.API.Comunications.Request.Response;
using RocketLeilao.API.Contracts;
using RocketLeilao.API.Entities;
using RocketLeilao.API.Services;
using RocketLeilao.API.UsesCases.Auctions.GetCurrent;
using RocketLeilao.API.UsesCases.Offers.CreateOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UseCases.Test.Offer.CreateOffer
{
	public class CreateOfferUseCaseTest
	{
		[Theory]// faz varias vezes o teste
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(3)]
		public void Success(int itemId)
		{

			//ARRANGE
			//Inicializar todo o necessario:

			//Usar Biblioteca para criar uma entidade falsa de acordo com as regras estabelecidas

			var request = new Faker<RequestCreatedOfferJson>()
				.RuleFor(request => request.Price, f => f.Random.Decimal(1, 900)).Generate();



			//gera um 'fake' repository. Usado apenas com interface pois cria uma implementacao da mesma
			var offerRepository = new Mock<IOfferRepository>();

			//define o valor de retorno: Quando alguem chamar a funcao getcurrent o mock vai retornar algo(leilao)

			var loggedUser = new Mock<ILoggedUser>();
			loggedUser.Setup(i => i.User()).Returns(new User());




			var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

			//ACT
			
			//salvando a funcao na variavel
			var act = () => useCase.Execute(itemId, request);


			//ASSERT
			//Testar os resultados
			//verifica se a variavel que salvou a funcao nao ira lancar uma exceção
			act.Should().NotThrow();


		}
	}
}
