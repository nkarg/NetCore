using Core.Abstract;
using Core.Entities;
using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Concrete
{
    public class SuperHeroManager : ISuperHero
    {
        public SuperHeroManager()
        {
            if (Database.SuperHeroes == null)
            {
                Database.SuperHeroes = new List<SuperHero>();
            }
        }

        public bool Add(SuperHeroEntity superHero)
        {
            var result = false;

            try
            {
                if (superHero != null)
                {
                    var hero = new SuperHero
                    {
                        Id = superHero.Id,
                        Name = superHero.Name,
                        Hability = superHero.Hability,
                        IsActive = superHero.IsActive
                    };

                    Database.SuperHeroes.Add(hero);

                    //Como nada fallo, esto es correcto
                    result = true;
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return result;
        }

        public bool DeleteById(int id)
        {
            var result = false;

            try
            {
                var query = (from sh in Database.SuperHeroes
                             where sh.Id.Equals(id)
                             select sh).FirstOrDefault();

                //var lambdaExpression = Database.SuperHeroes.FirstOrDefault(x => x.Id.Equals(id));

                if (query != null)
                {
                    //Remove indica si el elemento se elimino correctamente
                    result = Database.SuperHeroes.Remove(query);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return result;
        }

        public List<SuperHeroEntity> GetAll()
        {
            var result = new List<SuperHeroEntity>();

            try
            {
                var query = (from sh in Database.SuperHeroes
                             select new SuperHeroEntity
                             {
                                 Id = sh.Id,
                                 Name = sh.Name,
                                 Hability = sh.Hability,
                                 IsActive = sh.IsActive
                             }).ToList();

                if (query.Any())
                {
                    result.AddRange(query);
                }

                //foreach (var item in query)
                //{
                //    result.Add(new SuperHeroEntity
                //    {
                //        Id = item.Id,
                //        Name = item.Name,
                //        Hability = item.Hability,
                //        IsActive = item.IsActive
                //    });
                //}
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return result;
        }

        public SuperHeroEntity GetById(int id)
        {
            //return GetAll().Where(x => x.Id.Equals(id)).FirstOrDefault();

            //return Database.SuperHeroes.Where(x => x.Id.Equals(id)).Select(y => new SuperHeroEntity {
            //    Id = y.Id,
            //    Name = y.Name,
            //    Hability = y.Hability,
            //    IsActive = y.IsActive
            //}).FirstOrDefault();

            SuperHeroEntity result = null;

            try
            {
                var query = (from sh in Database.SuperHeroes
                             where sh.Id.Equals(id)
                             select new SuperHeroEntity
                             {
                                 Id = sh.Id,
                                 Name = sh.Name,
                                 Hability = sh.Hability,
                                 IsActive = sh.IsActive
                             }).FirstOrDefault();

                if (query != null)
                {
                    result = query;
                }

            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return result;
        }

        public bool Modify(SuperHeroEntity superHero)
        {
            var result = false;

            try
            {
                if(superHero != null)
                {
                    var query = Database.SuperHeroes.FirstOrDefault(x => x.Id.Equals(superHero.Id));
                    var index = Database.SuperHeroes.IndexOf(query);

                    if(index >= 0)
                    {
                        var hero = new SuperHero
                        {
                            Id = superHero.Id,
                            Name = superHero.Name,
                            Hability = superHero.Hability,
                            IsActive = superHero.IsActive
                        };

                        Database.SuperHeroes[index] = hero;

                        //Como nada fallo, esto es correcto
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return result;
        }
    }
}
