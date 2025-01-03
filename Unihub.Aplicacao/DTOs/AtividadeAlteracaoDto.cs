namespace Unihub.Aplicacao.DTOs
{
    public class AtividadeAlteracaoDto
    {
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public int? NotaId { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Status { get; set; }
    }
}
