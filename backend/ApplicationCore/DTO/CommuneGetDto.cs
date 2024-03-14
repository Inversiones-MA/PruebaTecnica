using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class CommuneGetDto
    {
        public short RegionCode { get; set; }

        public short CityCode { get; set; }
        public short Code { get; set; }

        public string Name { get; set; } = null!;

    }
}
