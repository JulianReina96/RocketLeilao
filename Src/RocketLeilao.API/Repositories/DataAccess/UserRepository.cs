using RocketLeilao.API.Contracts;
using RocketLeilao.API.Entities;

namespace RocketLeilao.API.Repositories.DataAccess
{
	public class UserRepository : IUserRepository
	{
		private readonly RocketLeilaoDbContext _dbcontext;
		public UserRepository(RocketLeilaoDbContext dbContext) => _dbcontext = dbContext;

		public bool ExistUserwithEmail(string email) => _dbcontext.Users.Any(user => user.Email.Equals(email));
		public User GetUserByEmail(string email) => _dbcontext.Users.First(user => user.Email.Equals(email));

	}
}
