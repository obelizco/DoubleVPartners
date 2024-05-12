using Back.Personas.Dominio.Commons;
using Back.Personas.Dominio.Dtos;
using Back.Personas.Dominio.Interfaces;
using MediatR;

namespace Back.Personas.CasosDeUso.People.Consultar
{
    public class ConsultarPersonaHandler : IRequestHandler<ConsultarPersonaRequest, ResponseBase<List<PersonaDto>>>
    {
        private readonly IPersonaRepository _personaRepository;
        public ConsultarPersonaHandler(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task<ResponseBase<List<PersonaDto>>> Handle(ConsultarPersonaRequest request, CancellationToken cancellationToken)
        {
            var data = await _personaRepository.GetAllAsync();
            var response = data.Select(s => new PersonaDto()
            {
                IdPersona = s.IdPersona,
                Nombres = s.Nombres,
                Apellidos = s.Apellidos,
                Email = s.Email,
                TipoIdentificacion = s.TipoIdentificacion,
                Identificacion= s.NumeroIdentificacion.ToString(),
                NombreCompleto = $"{s.Nombres} {s.Apellidos}",
                NumTipoIdenti=  $"{s.NumeroIdentificacion} {s.TipoIdentificacion}",
            }).ToList();
            return new ResponseBase<List<PersonaDto>>(
                message:"OK",
                data:response
                );
        }
    }
}
