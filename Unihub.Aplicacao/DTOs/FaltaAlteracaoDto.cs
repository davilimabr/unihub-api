using System.Text.Json.Serialization;

namespace Unihub.Aplicacao.DTOs
{
    public class FaltaAlteracaoDto
    {
        [JsonIgnore]
        public int AlunoId { get; set; }
        [JsonIgnore]
        public int DisciplinaId { get; set; }
        public DateTime Data { get; set; }
        public string Motivo { get; set; }
        public int Horas { get; set; }
    }
}
