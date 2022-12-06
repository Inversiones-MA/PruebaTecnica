using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Finfast.Desafio.Domain.Models
{
    public  class PersonaRequest
    {
        [JsonProperty("runCuerpo")]
        [Required(ErrorMessage = "Run es requerido")]
        public int RunCuerpo { get; set; }

        [JsonProperty("runDigito")]
        [Required(ErrorMessage = "Run digito es requerido")]
        public string RunDigito { get; set; }

        [JsonProperty("nombres")]
        [Required(ErrorMessage = "Nombres es requerido")]
        public string Nombres { get; set; }

        [JsonProperty("apellidoPaterno")]
        [Required(ErrorMessage = "ApellidoPaterno es requerido")]
        public string ApellidoPaterno { get; set; }

        [JsonProperty("apellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [JsonProperty("email")]
        [EmailAddress]
        public string Email { get; set; }

        [JsonProperty("sexoCodigo")]
        [Required(ErrorMessage = "SexoCodigo es requerido")]
        public short SexoCodigo { get; set; }

        [JsonProperty("fechaNacimiento")]            
        public DateTime? FechaNacimiento { get; set; }

        [JsonProperty("regionCodigo")]
        public short? RegionCodigo { get; set; }

        [JsonProperty("ciudadCodigo")]
        public short? CiudadCodigo { get; set; }

        [JsonProperty("comunaCodigo")]
        public short? ComunaCodigo { get; set; }

        [JsonProperty("direccion")]
        public string Direccion { get; set; }

        [JsonProperty("telefono")]
        public int? Telefono { get; set; }

        [JsonProperty("observaciones")]
        public string Observaciones { get; set; }
    }
}
