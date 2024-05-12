using Back.Personas.Dominio.Commons;
using Back.Personas.Dominio.Entities;
using Back.Personas.Dominio.Interfaces.Commons;
using Back.Personas.Persistencia.Builder;
using Microsoft.EntityFrameworkCore;

namespace Back.Personas.Persistencia.Context
{
    public class AplicationDBContext : DbContext
    {
        private readonly IUserAuthenticate _usuarioAutenticado;
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected AplicationDBContext(IUserAuthenticate usuarioAutenticado)
        {
           
            _usuarioAutenticado = usuarioAutenticado;
        }
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options, IUserAuthenticate usuarioAutenticado) : base(options)
        {
            _usuarioAutenticado = usuarioAutenticado;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                var userId = Guid.Parse(_usuarioAutenticado.UserId);
                DateTime date = DateTime.UtcNow;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.FechaCreacion = date;
                        entry.Entity.CreadoPor = userId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.FechaModificacion = date;
                        entry.Entity.ModificadoPor = userId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Persona();
            builder.Usuario();
            base.OnModelCreating(builder);
        }
    }
}
