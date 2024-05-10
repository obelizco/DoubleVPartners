namespace Back.Personas.Dominio.Interfaces.Commons
{
    public interface IUserAuthenticate
    {
        string UserId { get; }

        string tenantId { get; }

        int GetTenant();
        void AddUserToContext(string userId);
    }
}
