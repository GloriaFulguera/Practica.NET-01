using Microsoft.AspNetCore.Mvc;
using CRUD_CORE_MVC.Datos;
using CRUD_CORE_MVC.Models;

namespace CRUD_CORE_MVC.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            //Mostrar lista de contactos
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //Mostrar formulario
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //Accion Guardar
            if (!ModelState.IsValid)
                return View();
            var rta = _ContactoDatos.Guardar(oContacto);
            if (rta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Editar(int idContacto)
        {
            //Mostrar formulario editar
            var oContacto = _ContactoDatos.Obtener(idContacto);
            return View(oContacto);
        }
        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            //Accion Editar-Guardar
            if (!ModelState.IsValid)
                return View();
            var rta = _ContactoDatos.Editar(oContacto);
            if (rta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Eliminar(int idContacto)
        {
            //Mostrar formulario editar
            var oContacto = _ContactoDatos.Obtener(idContacto);
            return View(oContacto);
        }
        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {
            //Accion Editar-Guardar
            var rta = _ContactoDatos.Eliminar(oContacto.idContacto);
            if (rta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
