using Back.Personas.Dominio.Entities;
using Back.Personas.Dominio.Interfaces;
using Back.Personas.Persistencia.Context;
using Back.Personas.Persistencia.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Back.Personas.Persistencia.Repositories
{
    public class PersonaRepository : RepositoryGenericAsync<Persona>, IPersonaRepository
    {
        private readonly DbSet<Persona> _dbSet;
        private readonly AplicationDBContext _context;

        public PersonaRepository(AplicationDBContext dbContext, AplicationDBContext context) : base(dbContext)
        {
            _dbSet = dbContext.Set<Persona>();
            _context = context;
        }

        public async Task<List<Persona>> GetAllAsync()
        {
            var data = _dbSet.FromSqlRaw("exec dbo.ConsultaPersonas").ToList();
            return  data ;
        }
    }
}
