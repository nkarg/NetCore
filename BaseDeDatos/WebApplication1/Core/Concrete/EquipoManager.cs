using Core.Abstract;
using Core.Entities;
using Data.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Core.Concrete
{
    public class EquipoManager : IEquipo
    {
        private readonly ProDeContext _context;

        public EquipoManager(ProDeContext context)
        {
            _context = context;
        }

        public List<EquipoEntity> GetAll()
        {
            var result = new List<EquipoEntity>();
            try
            {
                var query = (from eq in _context.Equipo.Include(x => x.EquipoInfo)
                             select eq).ToList();

                if (query.Any())
                {
                    foreach (var item in query)
                    {
                        var equipo = new EquipoEntity
                        {
                            EquipoId = item.EquipoId,
                            Nombre = item.Nombre,
                            Codigo = item.Codigo

                        };

                        if(item.EquipoInfo != null)
                        {
                            var info = new EquipoInfoEntity
                            {
                                EquipoId = item.EquipoInfo.EquipoId,
                                Web = item.EquipoInfo.Web,
                                IconoUrl = item.EquipoInfo.IconoUrl,
                                Twitter = item.EquipoInfo.Twitter,
                                Instagram = item.EquipoInfo.Instagram
                            };

                            equipo.EquipoInfo = info;
                        }

                        result.Add(equipo);
                    }
                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return result;
        }
    }
}
