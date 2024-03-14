using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.SqlServerContext;

public partial class Persona
{
    public Guid Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? Run { get; set; }

    public int RunCuerpo { get; set; }

    public string RunDigito { get; set; } = null!;

    public string? Nombre { get; set; }

    public string Nombres { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public string? Email { get; set; }

    public short SexoCodigo { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public short? RegionCodigo { get; set; }

    public short? CiudadCodigo { get; set; }

    public short? ComunaCodigo { get; set; }

    public string? Direccion { get; set; }

    public int? Telefono { get; set; }

    public string? Observaciones { get; set; }

    public virtual Comuna? Comuna { get; set; }

    public virtual Sexo SexoCodigoNavigation { get; set; } = null!;
}
