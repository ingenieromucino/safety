using Safety.Web.Models.Commons;

namespace Safety.Web.Models.Entities.Clientes;

public class Cliente : EntidadBase
{
    public string NombreCliente { get; set; } = null!;
    public string NombreComercial { get; set; } = null!;
    public string RFC { get; set; } = null!;
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Estado { get; set; }
    public string? Municipio { get; set; }
    public ICollection<Ubicacion> Ubicaciones { get; set; } = new List<Ubicacion>();
}
