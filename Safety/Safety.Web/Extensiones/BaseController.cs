using Microsoft.AspNetCore.Mvc;
using Safety.Web.Models.Enums;

namespace Safety.Web.Extensiones;

public class BaseController : Controller
{
    public void NotificacionBasica(string mensaje, TipoNotificacion tipoNotificacion, string titulo = "")
    {
        TempData["notificacion"] = @$"Swal.fire('{titulo}','{mensaje.Replace("'", "")}','{tipoNotificacion.ToString().ToLower()}')";
    }

    public void NotificacionTiempo(string mensaje, TipoNotificacion tipoNotificacion, string titulo = "", int Tiempo = 0)
    {
        TempData["notificacion"] = @$"Swal.fire(" + "{" + @$"icon: '{tipoNotificacion.ToString().ToLower()}',title: '{titulo}',text: '{mensaje.Replace("'", "")}',timer: {Tiempo},showConfirmButton: false" + "}" + @$")";
    }

    public void NotificacionError(string mensaje)
    {
        TempData["notificacion"] = $"Swal.fire('error', '{mensaje.Replace("'", "")}', 'error')";
    }

    public void NotificacionAviso(string mensaje)
    {
        TempData["notificacion"] = $"Swal.fire('warning', '{mensaje.Replace("'", "")}', 'warning')";
    }

    public void NotificacionInformativa(string mensaje)
    {
        TempData["notificacion"] = $"Swal.fire('info', '{mensaje.Replace("'", "")}', 'info')";
    }

    public void NotificacionGuardado()
    {
        TempData["notificacion"] = @$"Swal.fire('Aviso','Registro guardado','{TipoNotificacion.Success.ToString().ToLower()}')";
    }

    public void NotificacionActualizacion()
    {
        TempData["notificacion"] = @$"Swal.fire('Aviso','Se actualiza la informacion','{TipoNotificacion.Success.ToString().ToLower()}')";
    }

    public void NotificacionEliminado()
    {
        TempData["notificacion"] = @$"Swal.fire('Aviso','Registro eliminado','{TipoNotificacion.Success.ToString().ToLower()}')";
    }
}
