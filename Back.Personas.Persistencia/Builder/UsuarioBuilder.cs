using Back.Personas.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back.Personas.Persistencia.Builder
{
    public static class UsuarioBuilder
    {
        public static void Usuario(this ModelBuilder modelBuilder)
       => modelBuilder.Entity<Usuario>(entity =>
       {
           entity.ToTable("Usuario")
               .HasKey(a => a.IdUsuario)
               .HasName("IdUsuario");
       });
    }
}
