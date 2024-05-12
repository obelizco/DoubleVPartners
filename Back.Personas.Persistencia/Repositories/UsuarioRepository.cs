using Back.Personas.Dominio.Entities;
using Back.Personas.Dominio.Interfaces;
using Back.Personas.Persistencia.Context;
using Back.Personas.Persistencia.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Back.Personas.Persistencia.Repositories
{
    public class UsuarioRepository : RepositoryGenericAsync<Usuario>, IUsuarioRepository
    {
        private readonly DbSet<Usuario> _dbSet;

        public UsuarioRepository(AplicationDBContext dbContext) : base(dbContext)
        {
            _dbSet= dbContext.Set<Usuario>();
        }

        public async Task<Usuario> GetUsuarioAsync(string user)
        {
            return await _dbSet.Where(p => p.NombreUsuario==user).FirstOrDefaultAsync();
        }
    }
}
