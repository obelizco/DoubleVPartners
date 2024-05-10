using Back.Personas.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back.Personas.Persistencia.Builder
{
    public static class PersonaBuilder
    {
        public static void Persona(this ModelBuilder modelBuilder)
          => modelBuilder.Entity<Persona>(entity =>
          {
              entity.ToTable("Persona")
                  .HasKey(a => a.IdPersona)
                  .HasName("IdPersona");
          });
    }
}
