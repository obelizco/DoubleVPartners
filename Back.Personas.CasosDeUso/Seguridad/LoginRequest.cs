using Back.Personas.Dominio.Commons;
using MediatR;

namespace Back.Personas.CasosDeUso.Seguridad
{
    public record LoginRequest(string usuario, string password): IRequest<ResponseBase<string>>;
}
