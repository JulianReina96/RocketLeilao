using RocketLeilao.API.Entities;
using RocketLeilao.API.Repositories;
using System.Text;

namespace RocketLeilao.API.Services
{
    public class LoggerUser
    {
        private readonly IHttpContextAccessor _httpContextAcessor;
        public LoggerUser(IHttpContextAccessor httpContext) {
        
            _httpContextAcessor = httpContext;
        }
        public User User()
        {
            var repository = new RocketLeilaoDbContext();
            var token = TokenOnRequest();
            var email = FromBase64String(token);
            
            return repository.Users.First(user =>  user.Email.Equals(email));

        }

        public string TokenOnRequest()
        {
            var authentication = _httpContextAcessor.HttpContext!.Request.Headers.Authorization.ToString();
            if (string.IsNullOrEmpty(authentication)) { throw new Exception("Token is Missing"); }

            //barear dGF0aWFuYUB0YXRpYW5hLmNvbQ==

            return authentication["Bearear".Length..];
        }

        private string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);
            return Encoding.UTF8.GetString(data);


        }
    }
}
