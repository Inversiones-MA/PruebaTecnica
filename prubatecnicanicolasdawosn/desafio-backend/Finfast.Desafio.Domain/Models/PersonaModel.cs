using Finfast.Desafio.Domain.Entities;
using Newtonsoft.Json;

namespace Finfast.Desafio.Domain.Models
{
    public class PersonaModel : PersonaRequest
    {
        [JsonProperty("id")]
        public System.Guid Id { get; set; }

        [JsonProperty("run")]
        public string Run { get; set; }

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }
        public virtual Comuna? Comuna { get; set; }
        public virtual Sexo Sexo { get; set; }
    }
}
