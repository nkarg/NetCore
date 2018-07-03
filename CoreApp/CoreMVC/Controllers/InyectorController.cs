using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEntity;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVC.Controllers
{
    public class InyectorController : Controller
    {
        private IFormateador _formateador;

        public InyectorController(IFormateador formateador)
        {
            _formateador = formateador;
        }

        public IActionResult Index()
        {
            var equipoA = new Equipo { EquipoId = 1, Nombre = "Argentina" };
            var equipoB = new Equipo { EquipoId = 2, Nombre = "Nigeria" };

            ViewBag.Formateador = _formateador.NombreCompleto(equipoB);
            IFormateador manager = HttpContext.RequestServices.GetService(typeof(IFormateador)) as IFormateador;
            var test = manager.NombreCompleto(equipoA);
            return View();
        }
    }
}