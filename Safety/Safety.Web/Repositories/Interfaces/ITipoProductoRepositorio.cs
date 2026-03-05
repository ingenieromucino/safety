using Safety.Web.Models.Entities.Configuraciones;
using Safety.Web.Repositories.Interfaces;

namespace Safety.Web.Repositories.Catalogos;

public interface ITipoProductoRepositorio : IBaseRepositorio<TipoProducto>
{
    Task<TipoProducto?> ObtenerPorNombreAsync(string nombre);
}