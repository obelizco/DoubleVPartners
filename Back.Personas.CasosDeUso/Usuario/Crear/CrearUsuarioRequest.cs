using Back.Personas.Dominio.Commons;
using Back.Personas.Dominio.Dtos;
using MediatR;

namespace Back.Personas.CasosDeUso.User.Crear
{
    public class CrearUsuarioRequest : IRequest<ResponseBase<UsuarioDto>>
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
    }
}
