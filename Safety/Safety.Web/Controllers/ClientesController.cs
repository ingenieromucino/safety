using Microsoft.AspNetCore.Mvc;
using Safety.Web.Extensiones;
using Safety.Web.Models.Entities.Clientes;

namespace Safety.Web.Controllers;

public class ClientesController(IClienteRepositorio clienteRepositorio) : BaseController
{

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var clientes = await clienteRepositorio.ObtenerTodosAsync();
        return View(clientes);
    }

    [HttpGet]
    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            await clienteRepositorio.AgregarAsync(cliente);
            return RedirectToAction(nameof(Index));
        }
        return View(cliente);
    }

    [HttpGet]
    public async Task<IActionResult> Editar(int id)
    {
        var cliente = await clienteRepositorio.ObtenerPorIdAsync(id);
        if (cliente == null) return NotFound();
        return View(cliente);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(int id, Cliente cliente)
    {
        if (id != cliente.Id) return BadRequest();

        if (ModelState.IsValid)
        {
            await clienteRepositorio.ActualizarAsync(cliente);
            return RedirectToAction(nameof(Index));
        }
        return View(cliente);
    }

    [HttpGet]
    public async Task<IActionResult> Eliminar(int id)
    {
        var cliente = await clienteRepositorio.ObtenerPorIdAsync(id);
        if (cliente == null) return NotFound();
        return View(cliente);
    }

    [HttpPost, ActionName("Eliminar")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ConfirmarEliminar(int id)
    {
        var cliente = await clienteRepositorio.ObtenerPorIdAsync(id);
        if (cliente == null) return NotFound();

        await clienteRepositorio.EliminarAsync(cliente);
        return RedirectToAction(nameof(Index));
    }
}