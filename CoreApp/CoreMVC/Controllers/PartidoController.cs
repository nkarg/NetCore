using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreEntity;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVC.Controllers
{
    public class PartidoController : Controller
    {
        private IFormateador _formateador;

        public PartidoController(IFormateador formateador)
        {
            _formateador = formateador;
        }

        public IActionResult Index()
        {
            var equipoA = new Equipo { EquipoId = 1, Nombre = "Argentina" };
            var equipoB = new Equipo { EquipoId = 2, Nombre = "Nigeria" };
            var partido = new Partido { EquipoLocal = equipoA, EquipoVisitante = equipoB, GolesLocal = 2, GolesVisitante = 1 };

            //Dynamic
            dynamic obj = new ExpandoObject();
            obj.Nombre = "Eduardo";

            //AnonymusType
            var anonymus = new { prop = "", prop2 = 2 };

            var test = _formateador.NombreCompleto(equipoA);
            ViewBag.Test = _formateador.NombreCompleto(equipoA);

            ViewBag.Dinamico = obj;
            ViewBag.Partido = partido;
            return View();
        }
    }
}