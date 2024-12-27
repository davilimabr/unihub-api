namespace Unihub.Aplicacao.DTOs
{
    public class DisciplinaAlteracaoDto
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Sala { get; set; }
        public int TotalHoras { get; set; }
        public int ProfessorId { get; set; }
    }
}
