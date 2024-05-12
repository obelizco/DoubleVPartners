using Back.Personas.Dominio.Commons;
using Back.Personas.Dominio.Dtos;
using MediatR;

namespace Back.Personas.CasosDeUso.People.Nuevo
{
    public class CrearPersonaRequest : IRequest<ResponseBase<PersonaDto>>
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public long Identificacion { get; set; }
        public string Email { get; set; }
        public string TipoIdentificacion { get; set; }
    }
}
