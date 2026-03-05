using Safety.Web.Models.Entities.Clientes;
using Safety.Web.Repositories.Interfaces;

public interface IClienteRepositorio : IBaseRepositorio<Cliente>
{
    Task<Cliente?> ObtenerPorRFCAsync(string rfc);
    Task<IEnumerable<Cliente>> BuscarPorNombreAsync(string nombre);
}