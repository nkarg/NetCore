using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract
{
    public interface ISuperHero
    {
        /// <summary>
        /// Adds a new SuperHero
        /// </summary>
        /// <param name="superHero"></param>
        /// <returns></returns>
        bool Add(SuperHeroEntity superHero);

        /// <summary>
        /// Modify an Super Hero
        /// </summary>
        /// <param name="superHero"></param>
        /// <returns></returns>
        bool Modify(SuperHeroEntity superHero);

        /// <summary>
        /// Delete an Super Hero
        /// </summary>
        /// <param name="id">Identificator</param>
        /// <returns></returns>
        bool DeleteById(int id);

        /// <summary>
        /// Get one speciic Super Hero
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SuperHeroEntity GetById(int id);

        /// <summary>
        /// Get All Super Heroes in Database
        /// </summary>
        /// <returns></returns>
        List<SuperHeroEntity> GetAll();
    }
}
