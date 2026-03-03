using Safety.Web.Entities.Catalogos;
using Safety.Web.Repositories.Interfaces;

namespace Safety.Web.Repositories.Catalogos;

public interface ITipoProductoRepositorio : IBaseRepositorio<TipoProducto>
{
    // Aquí podrías agregar métodos específicos de TipoProducto si se requieren
    Task<TipoProducto?> ObtenerPorNombreAsync(string nombre);
}