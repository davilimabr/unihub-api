using System.Text.Json.Serialization;

namespace Unihub.Aplicacao.DTOs
{
    public class LoginRetornoDto
    {
        public LoginRetornoDto(bool credenciaisValidas, AlunoDto? aluno = null)
        {
            CredenciaisValidas = credenciaisValidas;
            Aluno = aluno;
        }

        public bool CredenciaisValidas { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AlunoDto? Aluno { get; set; }
    }
}
