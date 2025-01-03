namespace Unihub.Aplicacao.DTOs
{
    public class AtividadeDetalhesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Status { get; set; }
        public AlunoDto Aluno { get; set; }
        public DisciplinaDto Disciplina { get; set; }
        public NotaDto? Nota { get; set; }
    }
}
