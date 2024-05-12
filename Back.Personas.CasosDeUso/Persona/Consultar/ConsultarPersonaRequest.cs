using Back.Personas.Dominio.Commons;
using Back.Personas.Dominio.Dtos;
using MediatR;

namespace Back.Personas.CasosDeUso.People.Consultar
{
    public class ConsultarPersonaRequest : IRequest<ResponseBase<List<PersonaDto>>>

    {

    }
}
