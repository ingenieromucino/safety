using Microsoft.EntityFrameworkCore;
using Safety.Web.Models.Entities.Configuraciones;
using System;

namespace Safety.Web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TipoProducto> TipoProductos => Set<TipoProducto>();

}
