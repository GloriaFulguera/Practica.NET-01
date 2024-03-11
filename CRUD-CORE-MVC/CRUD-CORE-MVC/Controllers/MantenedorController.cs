using Microsoft.AspNetCore.Mvc;
using CRUD_CORE_MVC.Datos;
using CRUD_CORE_MVC.Models;

namespace CRUD_CORE_MVC.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos=new ContactoDatos();
        public IActionResult Listar()
        {
            var oLista=_ContactoDatos.Listar();
            return View(oLista);
        }
    }
}
