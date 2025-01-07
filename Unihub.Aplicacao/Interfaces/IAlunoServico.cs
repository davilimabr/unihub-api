using Unihub.Aplicacao.DTOs;

namespace Unihub.Dominio.Interfaces
{
    public interface IAlunoServico
    {
        Task<bool> CadastrarAsync(AlunoAlteracaoDto dto);
        Task<bool> LogarAsync(LoginDto dto);
        Task<AlunoDto?> ObterPorIdAsync(int id);
        Task<List<AlunoDto>> ObterTodosAsync();
        Task<AlunoDto?> AtualizarAsync(int id, AlunoAlteracaoDto dto);
        Task<bool> ExcluirAsync(int id);
        Task<IEnumerable<DisciplinaDto>> ObterDisciplinasAsync(int alunoId);
    }
}
