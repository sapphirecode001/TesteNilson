using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Site_SmartComfort.Models
{
    public class PF
    {
        public int IdPF { get; set; }
        public long Cpf { get; set; }
        public string NomeCompleto { get; set; }
        public Usuario Usuario { get; set; } 
    }
}
