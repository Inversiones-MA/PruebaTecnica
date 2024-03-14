using System;
using System.Collections.Generic;

namespace Infrastructure.SqlServerContext;

public partial class Ciudad
{
    public short RegionCodigo { get; set; }

    public short Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Comuna> Comunas { get; set; } = new List<Comuna>();

    public virtual Region RegionCodigoNavigation { get; set; } = null!;
}
