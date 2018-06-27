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
        public IActionResult Index()
        {
            var equipoA = new Equipo { EquipoId = 1, Nombre = "Argentina" };
            var equipoB = new Equipo { EquipoId = 2, Nombre = "Nigeria" };
            var partido = new Partido { EquipoLocal = equipoA, EquipoVisitante = equipoB, GolesLocal = 2, GolesVisitante = 1 };

            dynamic obj = new ExpandoObject();
            obj.Nombre = "Eduardo";

            ViewBag.Dinamico = obj;
            ViewBag.Partido = partido;
            return View();
        }
    }
}