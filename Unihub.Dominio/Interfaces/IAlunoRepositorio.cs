using Unihub.Dominio.Entidades;

namespace Unihub.Dominio.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<Aluno> CriarAsync(Aluno aluno);
        Task<IEnumerable<Aluno>> ObterAsync(Func<Aluno, bool> condicao);
        Task<Aluno?> ObterPorIdAsync(int id);
        Task<IEnumerable<Aluno>> ObterTodosAsync();
        Task<Aluno?> AtualizarAsync(Aluno aluno);
        Task<bool> ExcluirAsync(int id);
        Task<IEnumerable<Disciplina>> ObterDisciplinasAsync(int id);
        Task<IEnumerable<Falta>> ObterFaltasAsync(int id);
        Task<IEnumerable<Atividade>> ObterAtividadesAsync(int id);
        Task<IEnumerable<AlunosDisciplina>> AdicionarDisciplinas(int idAluno, IEnumerable<int> idDisciplina);

    }
}
