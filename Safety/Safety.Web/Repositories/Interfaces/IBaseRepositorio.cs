using Safety.Web.Entities.Commons;

namespace Safety.Web.Repositories.Interfaces
{
    public interface IBaseRepositorio<T> where T : EntidadBase
    {
        Task<IEnumerable<T>> ObtenerTodosAsync(bool soloActivos = true);
        Task<T?> ObtenerPorIdAsync(int id);

        Task<int> AgregarAsync(T entidad);
        Task<int> ActualizarAsync(T entidad);
        Task<int> EliminarAsync(T entidad); 
    }
}