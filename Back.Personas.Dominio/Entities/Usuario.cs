using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Back.Personas.Dominio.Commons;

namespace Back.Personas.Dominio.Entities
{
    public class Usuario:AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdUsuario")]
        public Guid IdUsuario { get; set; }
        [Column("Usuario")]
        public string NombreUsuario { get; set; }
        [Column("Pass")]
        public string Contrasena { get; set; }

    }
}
