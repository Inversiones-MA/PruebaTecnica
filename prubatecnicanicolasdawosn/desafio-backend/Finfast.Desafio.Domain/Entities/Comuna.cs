namespace Finfast.Desafio.Domain.Entities
{
    public class Comuna
    {
        public short RegionCodigo { get; set; }

        public short CiudadCodigo { get; set; }

        public short Codigo { get; set; }

        public string Nombre { get; set; }

        public int CodigoPostal { get; set; }

        public int CodigoLibroClaseElectronico { get; set; }

        public virtual Ciudad Ciudad { get; set; }
    }
}
