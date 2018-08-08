using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Managers;
using Microsoft.AspNetCore.Mvc;
using Tabla.Models;

namespace Tabla.Controllers
{
    public class JugadorController : Controller
    {
        private readonly JugadorManager _jugadorManager;

        public JugadorController()
        {
            _jugadorManager = new JugadorManager();
        }

        public IActionResult Index()
        {
            var model = (from jg in _jugadorManager.Get()
                         select new JugadorViewModel {
                             Id = jg.Id,
                             Nombre = jg.Nombre,
                             Apellido = jg.Apellido,
                             Equipo = jg.Equipo,
                             EsTitular = jg.EsTitular,
                             Edad = jg.Edad()
                         });

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(JugadorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var jugador = new Jugador
                {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Equipo = model.Equipo,
                    EsTitular = model.EsTitular,
                    FechaNacimiento = model.FechaNacimiento
                };

                var result = _jugadorManager.AddPlayer(jugador);
                ViewBag.Result = result;
                ViewBag.Message = result ? "Agregado exitosamente" : "Algo Fallo";
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(JugadorViewModel model)
        {
            return View();
        }
    }
}