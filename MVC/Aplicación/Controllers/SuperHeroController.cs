using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicación.Models;
using Core.Abstract;
using Core.Concrete;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aplicación.Controllers
{
    public class SuperHeroController : Controller
    {
        private readonly ISuperHero _superHeroManager;

        public SuperHeroController(ISuperHero superHeroManager)
        {
            _superHeroManager = superHeroManager;
        }

        // GET ALL: SuperHero
        public IActionResult Index()
        {
            var model = (from sh in _superHeroManager.GetAll()
                         select new SuperHeroViewModel
                         {
                             Id = sh.Id,
                             Name = sh.Name,
                             Hability = sh.Hability,
                             IsActive = sh.IsActive
                         });

            //var model = _superHeroManager.GetAll();
            return View(model);
        }

        // GET BY ID: SuperHero
        public IActionResult Details(int id)
        {
            var model = new SuperHeroViewModel();
            var hero = _superHeroManager.GetById(id);
            if(hero != null)
            {
                model.Id = hero.Id;
                model.Name = hero.Name;
                model.Hability = hero.Hability;
                model.IsActive = hero.IsActive;
            }

            return View(model);
        }

        // ADD: SuperHero
        public IActionResult Add()
        {
            return View();
        }

        // ADD: SuperHero
        [HttpPost]
        public IActionResult Add(SuperHeroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hero = new SuperHeroEntity
                {
                    Id = model.Id.Value,
                    Name = model.Name,
                    Hability = model.Hability,
                    IsActive = model.IsActive
                };

                var result = _superHeroManager.Add(hero);

                ViewBag.Message = result ? "Agregado con exito!" : "Algo fallo";
            }

            return View();
        }

        // DELETE BY ID: SuperHero
        public IActionResult Delete()
        {
            return View();
        }

        // DELETE BY ID: SuperHero
        [HttpPost]
        public IActionResult Delete(SuperHeroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _superHeroManager.DeleteById(model.Id.Value);

                ViewBag.Message = result ? "Eliminado con exito!" : "Algo fallo";
            }

            return View();
        }

        // MODIFY: SuperHero
        public IActionResult Modify(int id)
        {
            var model = new SuperHeroViewModel();
            var hero = _superHeroManager.GetById(id);
            if (hero != null)
            {
                model.Id = hero.Id;
                model.Name = hero.Name;
                model.Hability = hero.Hability;
                model.IsActive = hero.IsActive;
            }

            return View(model);
        }

        // MODIFY: SuperHero
        [HttpPost]
        public IActionResult Modify(SuperHeroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hero = new SuperHeroEntity
                {
                    Id = model.Id.Value,
                    Name = model.Name,
                    Hability = model.Hability,
                    IsActive = model.IsActive
                };

                var result = _superHeroManager.Modify(hero);

                ViewBag.Message = result ? "Modificado con exito!" : "Algo fallo";
            }

            return View();
        }
    }
}