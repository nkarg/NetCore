using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Base.Controllers
{
    public class EquipoController : Controller
    {
        public IEquipo _equipoManager;

        public EquipoController(IEquipo equipoManager)
        {
            _equipoManager = equipoManager;
        }

        // GET: Equipo
        public IActionResult Index()
        {
            var model = _equipoManager.GetAll();

            return View(model);
        }

        // GET ById: Equipo
        public IActionResult Details(int id)
        {
            var model = _equipoManager.GetAll().Where(x => x.EquipoId.Equals(id)).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}