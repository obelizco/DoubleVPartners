namespace Back.Personas.Dominio.Dtos
{
    public class LoginDto 
    {
        public Guid IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Token { get; set; }
    }
}
