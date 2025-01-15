namespace Unihub.Aplicacao.DTOs
{
    public class DisciplinaDetalheDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Sala { get; set; }
        public int TotalHoras { get; set; }
        public string Professor { get; set; }
        public int Periodo { get; set; }
        public bool Obrigatoria { get; set; }
    }
}
