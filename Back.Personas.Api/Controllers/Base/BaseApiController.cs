using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Back.Personas.Api.Controllers.Base
{

    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    }

}
