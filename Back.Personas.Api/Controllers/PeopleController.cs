using Back.Personas.Api.Controllers.Base;
using Back.Personas.CasosDeUso.People.Consultar;
using Back.Personas.CasosDeUso.People.Nuevo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back.Personas.Api.Controllers
{
    [Authorize]
    public class PeopleController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CrearPersona(CrearPersonaRequest request)
        {
            var response = await Mediator.Send(request);

            return new ObjectResult(response)
            {
                StatusCode = response.Code
            };
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarPersonas()
        {
            var response = await Mediator.Send(new ConsultarPersonaRequest());

            return new ObjectResult(response)
            {
                StatusCode = response.Code
            };
        }
    }
}
