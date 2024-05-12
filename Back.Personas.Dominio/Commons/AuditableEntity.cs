namespace Back.Personas.Dominio.Commons
{
    public class AuditableEntity
    {
        public Guid CreadoPor { get; set; } = Guid.Empty;
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; } = Guid.Empty;
        public DateTime? FechaModificacion { get; set; }
    }
}
