namespace Back.Personas.Dominio.Interfaces.Commons
{
    public interface IRepositoryGenericAsync<T> where T : class
    {
        Task<T> ObtenerPorIdAsync(Guid id);
        Task<IReadOnlyList<T>> ObtenerTodosAsync();
        Task<IReadOnlyList<T>> ObtenerRespuestaPaginaAsync(int numeroPagina, int tamanoPagina);
        Task<T> AgregarAsync(T entity);
        Task ActualizarAsync(T entity);
        Task EliminarAsync(T entity);
    }
}
