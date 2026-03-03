namespace Safety.Web.Entities.Commons;

public abstract class EntidadBase
{
    public int Id { get; set; }
    public bool Activo { get; set; } = true;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
