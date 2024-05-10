using Back.Personas.Dominio.Interfaces.Commons;
using Back.Personas.Persistencia.Context;
using Microsoft.EntityFrameworkCore;

namespace Back.Personas.Persistencia.Repositories.Base
{
    public class RepositoryGenericAsync<T> : IRepositoryGenericAsync<T> where T : class
    {
        private readonly AplicationDBContext _dbContext;

        public RepositoryGenericAsync(AplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ActualizarAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> AgregarAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task EliminarAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> ObtenerPorIdAsync(Guid id) => await _dbContext.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> ObtenerRespuestaPaginaAsync(int numeroPagina, int tamanoPagina)
        {
            return await _dbContext
                .Set<T>()
                .Skip((numeroPagina - 1) * tamanoPagina)
                .Take(tamanoPagina)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ObtenerTodosAsync()
        {
            return await _dbContext
                 .Set<T>()
                 .ToListAsync();
        }
    }

}
