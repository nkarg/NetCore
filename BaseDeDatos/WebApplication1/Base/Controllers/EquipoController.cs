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
        private readonly IEquipo _equipoManager;

        public EquipoController(IEquipo equipoManager)
        {
            _equipoManager = equipoManager;
        }

        // GET: Equipo
        public ActionResult Index()
        {
            var model = _equipoManager.GetAll();
            
            return View(model);
        }
    }
}