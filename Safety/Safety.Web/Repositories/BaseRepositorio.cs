using Microsoft.EntityFrameworkCore;
using Safety.Web.Data;
using Safety.Web.Models.Commons;
using Safety.Web.Repositories.Interfaces;

public class BaseRepositorio<T> : IBaseRepositorio<T> where T : EntidadBase
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepositorio(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public async Task<IEnumerable<T>> ObtenerTodosAsync(bool soloActivos = true)
       => soloActivos ? await _dbSet.Where(x => x.Activo).ToListAsync() : await _dbSet.ToListAsync();

    public async Task<T?> ObtenerPorIdAsync(int id)
        => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    

    public async Task<int> AgregarAsync(T entidad)
    {
        await _dbSet.AddAsync(entidad);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> ActualizarAsync(T entidad)
    {
        _dbSet.Update(entidad);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> EliminarAsync(T entidad)
    {
        entidad.Activo = false;
        _dbSet.Update(entidad);
        return await _context.SaveChangesAsync();
    }
}