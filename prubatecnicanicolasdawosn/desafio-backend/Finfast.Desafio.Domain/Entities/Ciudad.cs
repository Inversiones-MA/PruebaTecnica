namespace Finfast.Desafio.Domain.Entities
{
    public class Ciudad
    {
        public Ciudad()
        {
            Comunas = new HashSet<Comuna>();
        }

        public short RegionCodigo { get; set; }

        public short Codigo { get; set; }

        public string Nombre { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Comuna> Comunas { get; set; }
    }
}
