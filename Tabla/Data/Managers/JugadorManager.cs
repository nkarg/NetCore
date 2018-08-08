using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Managers
{
    public class JugadorManager
    {
        public JugadorManager()
        {
            if(Database.Jugadores == null)
            {
                Database.Jugadores = new List<Jugador>();
            }
        }

        public List<Jugador> Get()
        {
            return Database.Jugadores;
        }

        public bool AddPlayer(Jugador jugador)
        {
            Database.Jugadores.Add(jugador);

            return true;
        }

        public bool ModifyPlayer(Jugador jugador)
        {
            var result = false;

            var player = Database.Jugadores.Find(x => x.Id.Equals(jugador.Id));
            var index = Database.Jugadores.IndexOf(player);

            if(index >= 0)
            {
                Database.Jugadores[index] = jugador;

                result = true;
            }

            return result;
        }
    }
}
