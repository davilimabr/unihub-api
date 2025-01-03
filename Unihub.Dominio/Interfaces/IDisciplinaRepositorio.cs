using Unihub.Dominio.Entidades;

namespace Unihub.Dominio.Interfaces
{
    public interface IDisciplinaRepositorio
    {
        Task<Disciplina> CriarAsync(Disciplina disciplina);
        Task<Disciplina?> ObterPorIdAsync(int id);
        Task<IEnumerable<Disciplina>> ObterTodasAsync();
        Task<Disciplina?> AtualizarAsync(Disciplina disciplina);
        Task<bool> ExcluirAsync(int id);
        Task<IEnumerable<HorarioAula>> ObterHorariosAulas(int idDisciplina);
        Task<HorarioAula> CriarHorarioAulaAsync(int idDisciplina, HorarioAula horarioAula);
        Task<bool> ExcluirHorarioAulaAsync(int idHorarioAula);
        Task<IEnumerable<Aluno>> ObterAlunosInscritosAsync(int idDisciplina);
        Task<IEnumerable<AlunosDisciplina>> InscreverAlunoAsync(int idDisciplina, IEnumerable<int> idAluno);
        Task DesinscreverAlunosAsync(int idDisciplina, IEnumerable<int> idsAlunos);
    }
}
