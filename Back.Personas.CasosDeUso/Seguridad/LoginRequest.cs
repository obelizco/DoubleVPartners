using Back.Personas.Dominio.Commons;
using Back.Personas.Dominio.Dtos;
using MediatR;

namespace Back.Personas.CasosDeUso.Seguridad
{
    public record LoginRequest(string usuario, string password): IRequest<ResponseBase<LoginDto>>;
}
