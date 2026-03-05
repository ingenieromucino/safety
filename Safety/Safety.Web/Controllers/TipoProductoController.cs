using Microsoft.AspNetCore.Mvc;
using Mapster;
using Safety.Web.Repositories.Interfaces;
using Safety.Web.Models.Entities.Configuraciones;
using Safety.Web.Models.ViewModels.Configuracion;

namespace Safety.Web.Controllers.Configuracion;

[Route("Configuracion/TiposProducto")]
public class TipoProductoController : Controller
{
    private readonly IBaseRepositorio<TipoProducto> _repo;

    public TipoProductoController(IBaseRepositorio<TipoProducto> repo)
    {
        _repo = repo;
    }


    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var lista = (await _repo.ObtenerTodosAsync())
            .OrderBy(x => x.Nombre)
            .Adapt<List<TipoProductoVM>>();

        return View(lista);
    }

    [HttpGet("Crear")]
    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost("Crear")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(TipoProductoVM vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var entidad = vm.Adapt<TipoProducto>();

        await _repo.AgregarAsync(entidad);

        // Después de crear → vamos a Editar
        return RedirectToAction(nameof(Editar), new { id = entidad.Id });
    }

    [HttpGet("Editar/{id}")]
    public async Task<IActionResult> Editar(int id)
    {
        var entidad = await _repo.ObtenerPorIdAsync(id);
        if (entidad == null) return NotFound();

        var vm = entidad.Adapt<TipoProductoVM>();

        return View(vm);
    }

    [HttpPost("Editar/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(int id, TipoProductoVM vm)
    {
        if (id != vm.Id) return BadRequest();

        if (!ModelState.IsValid)
            return View(vm);

        var entidad = await _repo.ObtenerPorIdAsync(id);
        if (entidad == null) return NotFound();

        entidad.Nombre = vm.Nombre;
        entidad.Descripcion = vm.Descripcion;

        await _repo.ActualizarAsync(entidad);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost("Eliminar/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Eliminar(int id)
    {
        var entidad = await _repo.ObtenerPorIdAsync(id);

        if (entidad != null)
            await _repo.EliminarAsync(entidad);

        return RedirectToAction(nameof(Index));
    }
}