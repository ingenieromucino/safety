using Safety.Web.Entities.Commons;

namespace Safety.Web.Entities.Catalogos;

public class TipoProducto : EntidadBase
{
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    
    //public ICollection<Caracteristica> Caracteristicas { get; set; } = new List<Caracteristica>();
    //public ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
