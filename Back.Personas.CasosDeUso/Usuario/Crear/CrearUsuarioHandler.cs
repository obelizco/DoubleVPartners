using System.Net;
using AutoMapper;
using Back.Personas.CasosDeUso.People.ExtensionValidation;
using Back.Personas.CasosDeUso.People.Nuevo;
using Back.Personas.Dominio.Commons;
using Back.Personas.Dominio.Dtos;
using Back.Personas.Dominio.Entities;
using Back.Personas.Dominio.Interfaces;
using FluentValidation;
using MediatR;

namespace Back.Personas.CasosDeUso.User.Crear
{
    public sealed class CrearUsuarioHandler : IRequestHandler<CrearUsuarioRequest, ResponseBase<UsuarioDto>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IValidator<CrearUsuarioRequest> _crearValidator;
        private readonly IMapper _mapper;
        public CrearUsuarioHandler(IUsuarioRepository usuarioRepository, IMapper mapper, IValidator<CrearUsuarioRequest> crearValidator)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _crearValidator = crearValidator;
        }

        public async Task<ResponseBase<UsuarioDto>> Handle(CrearUsuarioRequest request, CancellationToken cancellationToken)
        {
            var result = await _crearValidator.ValidateAsync(request);
            if (!result.IsValid)
            {
                var error = result.ResultErrors();
                return new ResponseBase<UsuarioDto>(
                    code: HttpStatusCode.BadRequest,
                    errors: error
                );
            }
            var passHash = BCrypt.Net.BCrypt.HashPassword(request.Contrasena);
            var entidad = _mapper.Map<Usuario>(request);
            entidad.Contrasena = passHash;
            var response = await _usuarioRepository.AgregarAsync(entidad);
            if (response is not null)
            {
                var data = _mapper.Map<UsuarioDto>(response);
                return new ResponseBase<UsuarioDto>(
                    code: HttpStatusCode.Created,
                    message: "OK",
                    data: data
                    );
            }
            else
            {
                return new ResponseBase<UsuarioDto>(
                     code: HttpStatusCode.BadRequest,
                     message: "Problemas al crear"
                     );
            }
        }
    }
}
