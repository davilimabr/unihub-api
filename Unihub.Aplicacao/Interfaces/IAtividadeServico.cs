using Unihub.Aplicacao.DTOs;

namespace Unihub.Aplicacao.Interfaces
{
    public interface IAtividadeServico
    {
        Task<AtividadeDto> CriarAsync(AtividadeAlteracaoDto dto);
        Task<AtividadeDetalhesDto?> ObterPorIdAsync(int id);
        Task<List<AtividadeDto>> ObterTodasAsync();
        Task<AtividadeDto?> AtualizarAsync(int id, AtividadeAlteracaoDto dto);
        Task<bool> ExcluirAsync(int id);
        Task<IEnumerable<AtividadeDetalhesDto>> ObterPorAluno(int idAluno);
    }
}
