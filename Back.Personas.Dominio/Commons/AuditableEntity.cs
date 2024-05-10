namespace Back.Personas.Dominio.Commons
{
    public class AuditableEntity
    {
        public string CreadoPor { get; set; } = "";
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = "";
        public DateTime? FechaModificacion { get; set; }
    }
}
