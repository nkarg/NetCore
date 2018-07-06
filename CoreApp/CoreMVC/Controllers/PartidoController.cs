using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreMVC.Controllers
{
    public class PartidoController : Controller
    {
        private IFormateador _formateador;
        private ILogger _logger;

        public PartidoController(IFormateador formateador, ILogger<PartidoController> logger)
        {
            _formateador = formateador;
            _logger = logger;
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

        public IActionResult Resultado(string eq1, string eq2)
        {
            _logger.LogInformation("Aplicación ASP RESULTADO");

            if (eq1.Equals("boca") || eq2.Equals("boca"))
            {
                var error = new PartidoErrorException { Equipo1 = eq1, Equipo2 = eq2 };

                _logger.LogError(error.ToString());
            }

            

            var equipoA = new Equipo { EquipoId = 1, Nombre = eq1 };
            var equipoB = new Equipo { EquipoId = 2, Nombre = eq2 };
            
            return View();
        }
    }
}