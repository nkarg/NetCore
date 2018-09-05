using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ApiREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporadaController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IEquipo _equipoManager;

        public TemporadaController(IMemoryCache memoryCache, IEquipo equipoManager)
        {
            _memoryCache = memoryCache;
            _equipoManager = equipoManager;
            _memoryCache.CreateEntry("TorneosPrueba");
        }

        // GET api/values/
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "value";
        }

        // GET api/values/7
        /// <summary>
        /// Obtiene un equipo mediante un ID especifico
        /// </summary>
        /// <param name="id">Id del Equipo</param>
        /// <returns>Un Equipo</returns>
        [HttpGet("{id}")]
        public ActionResult<List<EquipoEntity>> Get(int id)
        {
            var equipos = new List<EquipoEntity>();
            var cache = _memoryCache.GetOrCreate("Equipos", entry =>
            {
                return _equipoManager.GetAll();
            });

            foreach (var item in cache)
            {
                if (item.EquipoId.Equals(id))
                {
                    var strEquipo = JsonConvert.SerializeObject(item);
                    return Ok(strEquipo);
                }
            }

            return NotFound($"Equipo con ID: {id} no encontrado");
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
