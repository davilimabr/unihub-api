using Unihub.Aplicacao.DTOs;

namespace Unihub.Aplicacao.Interfaces
{
    public interface IDisciplinaServico
    {
        Task<DisciplinaDto> CriarAsync(DisciplinaAlteracaoDto dto);
        Task<DisciplinaDetalheDto?> ObterPorIdAsync(int id);
        Task<IEnumerable<DisciplinaDto>> ObterTodasAsync();
        Task<IEnumerable<DisciplinaDto>> ObterPorAluno(int idAluno);
        Task<DisciplinaDto?> AtualizarAsync(int id, DisciplinaAlteracaoDto dto);
        Task<bool> ExcluirAsync(int id);
        Task<IEnumerable<AlunoDto>> ObterAlunosInscritosAsync(int idDisciplina);
        Task<IEnumerable<AlunosDisciplinaDto>> InscreverAlunoAsync(int idDisciplina, IEnumerable<int> idAluno);
        Task DesinscreverAlunosAsync(int idDisciplina, IEnumerable<int> idsAlunos);
        Task<FaltaDto> RegistrarFalta(int idDisciplina, FaltaAlteracaoDto falta);
    }
}
