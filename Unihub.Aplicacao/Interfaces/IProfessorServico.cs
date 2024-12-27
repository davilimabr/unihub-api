using Unihub.Aplicacao.DTOs;

namespace Unihub.Aplicacao.Interfaces
{
    public interface IProfessorServico
    {
        Task<ProfessorDto> CriarAsync(ProfessorAlteracaoDto dto);
        Task<ProfessorDto?> ObterPorIdAsync(int id);
        Task<List<ProfessorDto>> ObterTodosAsync();
        Task<ProfessorDto?> AtualizarAsync(int id, ProfessorAlteracaoDto dto);
        Task<bool> ExcluirAsync(int id);
    }
}
