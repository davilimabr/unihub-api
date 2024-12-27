namespace Unihub.Aplicacao.DTOs
{
    public class DisciplinaFaltasDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public IEnumerable<FaltaDto> Faltas { get; set; }
    }
}

