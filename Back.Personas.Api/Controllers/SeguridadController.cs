using Back.Personas.Api.Controllers.Base;
using Back.Personas.CasosDeUso.Seguridad;
using Back.Personas.CasosDeUso.User.Crear;
using Microsoft.AspNetCore.Mvc;

namespace Back.Personas.Api.Controllers
{

    public class SeguridadController : BaseApiController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await Mediator.Send(request);

            return new ObjectResult(response)
            {
                StatusCode = response.Code
            };
        }

        [HttpPost("RegistrarUsuario")]
        public async Task<IActionResult> CrearUsuario(CrearUsuarioRequest request)
        {
            var response = await Mediator.Send(request);

            return new ObjectResult(response)
            {
                StatusCode = response.Code
            };
        }
    }
}
