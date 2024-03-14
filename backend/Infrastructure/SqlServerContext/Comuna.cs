using System;
using System.Collections.Generic;

namespace Infrastructure.SqlServerContext;

public partial class Comuna
{
    public short RegionCodigo { get; set; }

    public short CiudadCodigo { get; set; }

    public short Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public int CodigoPostal { get; set; }

    public int CodigoLibroClaseElectronico { get; set; }

    public virtual Ciudad Ciudad { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
