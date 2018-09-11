// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace swagger.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class EquipoEntity
    {
        /// <summary>
        /// Initializes a new instance of the EquipoEntity class.
        /// </summary>
        public EquipoEntity()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the EquipoEntity class.
        /// </summary>
        public EquipoEntity(int? equipoId = default(int?), string nombre = default(string), string codigo = default(string), EquipoInfoEntity equipoInfo = default(EquipoInfoEntity))
        {
            EquipoId = equipoId;
            Nombre = nombre;
            Codigo = codigo;
            EquipoInfo = equipoInfo;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "equipoId")]
        public int? EquipoId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "codigo")]
        public string Codigo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "equipoInfo")]
        public EquipoInfoEntity EquipoInfo { get; set; }

    }
}