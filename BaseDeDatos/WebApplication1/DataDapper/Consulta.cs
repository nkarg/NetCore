using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper
{
    public static class Consulta
    {
        public static async Task<Equipo> DevolverEquiposAsync()
        {
            var result = new Equipo();
            var sql = "select * from equipo.Equipo where EquipoId = @EquipoId";
            using (var connection = new SqlConnection("Server=SIBPC05-PC/SQLEXPRESS;Database=ProDe;Trusted_Connection=True;"))
            {
                var param = new DynamicParameters();
                param.Add("@EquipoId", 1);

                try
                {
                    var equipo = await SqlMapper.QueryAsync<Equipo>(connection, sql, param);

                    if(equipo != null)
                    {
                        result = equipo.First();
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }

            return result;
        }
    }

    public class Equipo
    {
        public int MyFirstProperty { get; set; }
        public int MySecondProperty { get; set; }
    }
}
