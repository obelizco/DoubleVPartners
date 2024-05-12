using System.Net;
using AutoMapper;
using Back.Personas.CasosDeUso.People.ExtensionValidation;
using Back.Personas.CasosDeUso.Service;
using Back.Personas.Dominio.Commons;
using Back.Personas.Dominio.Dtos;
using Back.Personas.Dominio.Entities;
using Back.Personas.Dominio.Interfaces;
using FluentValidation;
using MediatR;

namespace Back.Personas.CasosDeUso.People.Nuevo
{
    public sealed class CrearPersonaHandler : IRequestHandler<CrearPersonaRequest, ResponseBase<PersonaDto>>
    {
        private readonly IValidator<CrearPersonaRequest> _crearValidator;
        private readonly IMapper _mapper;
        private readonly IPersonaRepository _personaRepository;
        public CrearPersonaHandler(IValidator<CrearPersonaRequest> crearValidator, IPersonaRepository personaRepository, IMapper mapper, JwtService jwtService)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
            _crearValidator = crearValidator;
        }


        public async Task<ResponseBase<PersonaDto>> Handle(CrearPersonaRequest request, CancellationToken cancellationToken)
        {

            var result = await _crearValidator.ValidateAsync(request);
            if (!result.IsValid)
            {
                var error = result.ResultErrors();
                return new ResponseBase<PersonaDto>(
                    code: HttpStatusCode.BadRequest,
                    errors: error
                );
            }

            var entidad = _mapper.Map<Persona>(request);
            var response = await _personaRepository.AgregarAsync(entidad);

            if (response is not null)
            {
                var data = _mapper.Map<PersonaDto>(response);
                data.NombreCompleto = data.Nombres + " " + data.Apellidos;
                data.NumTipoIdenti = data.Identificacion  + " " + data.TipoIdentificacion;
                return new ResponseBase<PersonaDto>(
                    code: HttpStatusCode.Created,
                    message: "OK",
                    data: data
                    );
            }
            else
            {
                return new ResponseBase<PersonaDto>(
                     code: HttpStatusCode.BadRequest,
                     message: "Problemas al crear"
                     );
            }

        }
    }
}
