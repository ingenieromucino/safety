using Safety.Web.Models.Commons;

namespace Safety.Web.Models.Entities.Configuraciones;

public class TipoProducto : EntidadBase
{
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    
    //public ICollection<Caracteristica> Caracteristicas { get; set; } = new List<Caracteristica>();
    //public ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
