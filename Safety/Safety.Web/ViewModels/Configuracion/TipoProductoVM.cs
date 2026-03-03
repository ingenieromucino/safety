using System.ComponentModel.DataAnnotations;

namespace Safety.Web.ViewModels.Configuracion;

public class TipoProductoVM
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(250)]
    public string? Descripcion { get; set; }
}