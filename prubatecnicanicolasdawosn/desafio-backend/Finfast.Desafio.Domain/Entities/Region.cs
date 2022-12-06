namespace Finfast.Desafio.Domain.Entities
{
    public class Region
    {
        public Region()
        {
            Ciudades = new HashSet<Ciudad>();
        }

        public short Codigo { get; set; }

        public string Nombre { get; set; }

        public string NombreOficial { get; set; }

        public int CodigoLibroClaseElectronico { get; set; }

        public virtual ICollection<Ciudad> Ciudades { get; set; }
    }
}
