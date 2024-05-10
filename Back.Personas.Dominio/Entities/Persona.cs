using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Back.Personas.Dominio.Commons;

namespace Back.Personas.Dominio.Entities
{
    public class Persona: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdPersona")]
        public Guid IdPersona { get; set; }
        [Column("Nombres")]
        public string Nombres { get; set; }
        [Column("Apellidos")]
        public string Apellidos { get; set; }
        [Column("Identificacion")]
        public string Identificacion { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("TipoIdentificacion")]
        public string TipoIdentificacion { get; set; }
  

    }
}
