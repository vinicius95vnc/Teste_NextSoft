using System.ComponentModel;

namespace NextSoft.Models
{
    public class Morador
    {
        [DisplayName("Identificação")]
        public int Id { get; set; }
        [DisplayName("Familia")]
        public int Id_Familia { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
    }
}
