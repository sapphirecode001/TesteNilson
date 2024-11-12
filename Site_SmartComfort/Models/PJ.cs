namespace Site_SmartComfort.Models
{
    public class PJ
    {
        public int IdPJ { get; set; }
        public string RazaoSocial { get; set; }
        public long Cnpj { get; set; }
        public string NomeResponsavel { get; set; }
        public Usuario Usuario { get; set; }
    }
}
