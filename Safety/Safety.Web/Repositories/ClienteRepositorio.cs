using Microsoft.EntityFrameworkCore;
using Safety.Web.Data;
using Safety.Web.Models.Entities.Clientes;
using Safety.Web.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ClienteRepositorio : BaseRepositorio<Cliente>, IClienteRepositorio
{
    public ClienteRepositorio(AppDbContext context) : base(context)
    {
    }

    public async Task<Cliente?> ObtenerPorRFCAsync(string rfc)
        => await _dbSet.FirstOrDefaultAsync(c => c.RFC == rfc);

    public async Task<IEnumerable<Cliente>> BuscarPorNombreAsync(string nombre)
        => await _dbSet.Where(c => c.NombreCliente.Contains(nombre)).ToListAsync();

}