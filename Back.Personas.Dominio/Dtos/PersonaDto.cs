using Back.Personas.Dominio.Commons;

namespace Back.Personas.Dominio.Dtos
{
    public class PersonaDto
    {
        public Guid IdPersona { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Email { get; set; }
        public string TipoIdentificacion { get; set; }
        public string? NumTipoIdenti { get; set; }
        public string? NombreCompleto { get; set; }

    }
}
