using System.Security.Claims;
using Back.Personas.Dominio.Interfaces.Commons;

namespace Back.Personas.Api.Services
{
    public class UserAuthenticate : IUserAuthenticate
    {
        public UserAuthenticate(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext.User.FindFirstValue("uid")?? Guid.Empty.ToString();
        }

        public string UserId { get; }
    }
}
