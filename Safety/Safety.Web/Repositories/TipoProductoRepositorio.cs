using Microsoft.EntityFrameworkCore;
using Safety.Web.Data;
using Safety.Web.Entities.Catalogos;

namespace Safety.Web.Repositories.Catalogos;

public class TipoProductoRepositorio : BaseRepositorio<TipoProducto>, ITipoProductoRepositorio
{
    public TipoProductoRepositorio(AppDbContext context) : base(context)
    {
    }

    public async Task<TipoProducto?> ObtenerPorNombreAsync(string nombre)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Nombre == nombre && x.Activo);
    }
}