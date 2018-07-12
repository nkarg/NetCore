using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Core.Entities;

namespace CoreAuth.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IHostingEnvironment _environment;

        public HomeController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            ViewBag.Environment = _environment.EnvironmentName;

            //PRUEBAS

            var obj1 = new ClaseMaestra();
            var obj2 = new ClaseDerivada();
            ClaseMaestra obj3 = new ClaseDerivada();

            var test1 = obj1.Metodo();
            var test2 = obj1.MetodoVirtual();

            var test3 = obj2.Metodo();
            var test4 = obj2.MetodoVirtual();
            var test5 = obj2.MetodoBase();
            var test6 = obj2.MetodoVirtualBase();

            var test7 = obj3.Metodo();
            var test8 = obj3.MetodoVirtual();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
