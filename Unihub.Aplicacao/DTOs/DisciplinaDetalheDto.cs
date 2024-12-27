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
        public ProfessorDto Professor { get; set; }
        //Adicionar outras informações conforme for seguindo a implementação, exemplo, lista de atividades, aulas na semana e etc
    }
}
