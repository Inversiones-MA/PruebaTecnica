using System;
using System.Collections.Generic;

namespace Infrastructure.SqlServerContext;

public partial class Commune
{
    public short RegionCode { get; set; }

    public short CityCode { get; set; }

    public short Code { get; set; }

    public string Name { get; set; } = null!;

    public int CodicePostale { get; set; }

    public int CodeBookClassElectronic { get; set; }

}
