using Back.Personas.Dominio.Entities;
using Back.Personas.Dominio.Interfaces.Commons;

namespace Back.Personas.Dominio.Interfaces
{
    public interface IUsuarioRepository : IRepositoryGenericAsync<Usuario>
    {
       public Task<Usuario>GetUsuarioAsync(string user);

    }
}
