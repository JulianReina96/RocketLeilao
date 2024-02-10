using RocketLeilao.API.Entities;

namespace RocketLeilao.API.Contracts
{
	public interface IUserRepository
	{
		public bool ExistUserwithEmail(string email);
		public User GetUserByEmail(string email);
	}
}
