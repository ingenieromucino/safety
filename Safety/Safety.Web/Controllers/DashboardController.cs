using Microsoft.AspNetCore.Mvc;
using Safety.Web.Extensiones;

namespace Safety.Web.Controllers;

public class DashboardController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }
}
