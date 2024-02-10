using RocketLeilao.API.Contracts;
using RocketLeilao.API.Entities;
using RocketLeilao.API.Repositories;
using System.Text;

namespace RocketLeilao.API.Services
{
    public class LoggerUser : ILoggedUser
    {
        private readonly IHttpContextAccessor _httpContextAcessor;
        private readonly IUserRepository _repository;
        public LoggerUser(IHttpContextAccessor httpContext, IUserRepository repository) {
        
            _httpContextAcessor = httpContext;
            _repository = repository;
        }
        public User User()
        {
            var token = TokenOnRequest();
            var email = FromBase64String(token);
            
            return _repository.GetUserByEmail(email);

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
