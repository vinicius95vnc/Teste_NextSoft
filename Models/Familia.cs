using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextSoft.Models
{
    public class Familia
    {
        [DisplayName("Identificação")]
        public int Id { get; set; }
        public string? Nome { get; set; }
        [DisplayName("Condominio")]
        public int Id_Condominio { get; set; }
        [DisplayName("Apartamento N°")]
        public int Apto { get; set; }

        [Column("AreaAPTO")]
        [DisplayName("área do Apto")]
        public string? AreaApto { get; set; }

        [Column("IPTU")]
        public int IPTU { get; set; }
    }
}
