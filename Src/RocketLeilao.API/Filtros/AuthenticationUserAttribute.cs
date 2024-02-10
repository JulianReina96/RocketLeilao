using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketLeilao.API.Contracts;
using RocketLeilao.API.Repositories;
using System.Text;


namespace RocketLeilao.API.Filtros
{
    public class AuthenticationUserAttribute : AuthorizeAttribute , IAuthorizationFilter
    {
        private readonly IUserRepository _repository;
            public AuthenticationUserAttribute(IUserRepository repository) => _repository = repository;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try { 
            var token = TokenOnRequest(context.HttpContext);
            var email = FromBase64String(token);

            var exists = _repository.ExistUserwithEmail(email);

            } catch(Exception ex)
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);

            }
        }
        public string TokenOnRequest (HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();
            if (string.IsNullOrEmpty(authentication) ) { throw new Exception("Token is Missing"); }

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
