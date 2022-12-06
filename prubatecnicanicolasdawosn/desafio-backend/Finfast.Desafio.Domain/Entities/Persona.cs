using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finfast.Desafio.Domain.Entities
{
    public class Persona
    {
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string? Run { get; set; }

        public int RunCuerpo { get; set; }

        public string RunDigito { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string? Nombre { get; set; }

        public string Nombres { get; set; }

        public string ApellidoPaterno { get; set; }

        public string? ApellidoMaterno { get; set; }

        public string? Email { get; set; }

        public short SexoCodigo { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public short? RegionCodigo { get; set; }

        public short? CiudadCodigo { get; set; }

        public short? ComunaCodigo { get; set; }

        public string? Direccion { get; set; }

        public int? Telefono { get; set; }

        public string? Observaciones { get; set; }

        public virtual Comuna? Comuna { get; set; }
        public virtual Sexo Sexo { get; set; }
    }
}
