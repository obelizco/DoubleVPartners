using Back.Personas.Dominio.Entities;
using Back.Personas.Dominio.Interfaces.Commons;

namespace Back.Personas.Dominio.Interfaces
{
    public interface IPersonaRepository : IRepositoryGenericAsync<Persona>
    {
        public Task<List<Persona>> GetAllAsync();

    }
}
