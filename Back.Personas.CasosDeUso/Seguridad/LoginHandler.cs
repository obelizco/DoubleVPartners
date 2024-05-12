using System.Net;
using AutoMapper;
using Back.Personas.CasosDeUso.Service;
using Back.Personas.Dominio.Commons;
using Back.Personas.Dominio.Dtos;
using Back.Personas.Dominio.Interfaces;
using MediatR;

namespace Back.Personas.CasosDeUso.Seguridad
{
    public sealed class LoginHandler : IRequestHandler<LoginRequest, ResponseBase<string>>
    {
        private readonly JwtService _jwtService;
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginHandler(IUsuarioRepository usuarioRepository, IMapper mapper, JwtService jwtService)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _jwtService = jwtService;   
        }

        public async Task<ResponseBase<string>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _usuarioRepository.GetUsuarioAsync(request.usuario);
            var password = user?.Contrasena is not null ? user.Contrasena : null;
            if(user is null)
            {
                return new ResponseBase<string>(
                   code: HttpStatusCode.NotAcceptable,
                   message: "Usuario no encontrado"
                   );

            }

            if (!BCrypt.Net.BCrypt.Verify(request.password, password))
            {
                return new ResponseBase<string>(
                    code: HttpStatusCode.NotAcceptable,
                    message: "Usuario y/o contraseña invalidos"
                    );

            }
            var userToken = _mapper.Map<UsuarioDto>(user);
            var token = _jwtService.GenerateToken(userToken);

            return new ResponseBase<string>(
                    code: HttpStatusCode.Accepted,
                    message:"OK",
                    data:token
                    );
        }
    }
}
