using Unihub.Aplicacao.DTOs;

namespace Unihub.Aplicacao.Interfaces
{
    public interface IDisciplinaServico
    {
        Task<DisciplinaDto> CriarAsync(DisciplinaAlteracaoDto dto);
        Task<DisciplinaDetalheDto?> ObterPorIdAsync(int id);
        Task<List<DisciplinaDto>> ObterTodasAsync();
        Task<DisciplinaDto?> AtualizarAsync(int id, DisciplinaAlteracaoDto dto);
        Task<bool> ExcluirAsync(int id);
        Task<IEnumerable<HorarioAulaDto>> ObterHorariosAulasAsync(int idDisciplina);
        Task<HorarioAulaAlteracaoDto> CriarHorarioAulaAsync(int idDisciplina, HorarioAulaAlteracaoDto horarioAula);
        Task<bool> ExcluirHorariosAulaAsync(int idHorarioAula);
        Task<IEnumerable<AlunoDto>> ObterAlunosInscritosAsync(int idDisciplina);
        Task<IEnumerable<AlunosDisciplinaDto>> InscreverAlunoAsync(int idDisciplina, IEnumerable<int> idAluno);
        Task DesinscreverAlunosAsync(int idDisciplina, IEnumerable<int> idsAlunos);
    }
}
