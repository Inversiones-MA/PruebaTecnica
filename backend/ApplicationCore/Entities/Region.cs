using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Region
    {
        public short Code { get; set; }

        public string Name { get; set; } = null!;

        public string OficialName { get; set; } = null!;

    }
}
