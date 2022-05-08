using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextSoft.Models
{
    public class Condominio
    {
        [DisplayName("Identificação")]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Bairro { get; set; }

        [Column("AreaTotal")]
        [DisplayName("Área Total Condominio")]
        public int AreaTotal { get; set; }

        [Column("IPTU")]
        public int IPTU { get; set; }
    }
}
