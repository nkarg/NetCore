﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Core.Entities;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace CoreAuth.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IHostingEnvironment _environment;
        private IFileProvider _fileProvider;

        public HomeController(IHostingEnvironment environment, IFileProvider fileProvider)
        {
            _environment = environment;
            _fileProvider = fileProvider;
        }

        public IActionResult Index()
        {
            ViewBag.Environment = _environment.EnvironmentName;

            var provider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            var contents = provider.GetDirectoryContents(string.Empty);
            var fileInfo = provider.GetFileInfo("wwwroot/js/site.js");
            var path = Path.Combine("advisor", "caco");
            var contents2 = _fileProvider.GetDirectoryContents(path);

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
        
        [Route("Home/Test/{dataA}-{dataB}/{id?}")]
        public IActionResult Test([FromRoute]string dataA, [FromRoute]string dataB, [FromQuery]string id, [FromQuery]string opcional)
        {
            var test = new { DataA = dataA, DataB = dataB, Opcional = id };
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
