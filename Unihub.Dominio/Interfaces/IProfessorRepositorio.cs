using Unihub.Dominio.Entidades;

namespace Unihub.Dominio.Interfaces
{
    public interface IProfessorRepositorio
    {
        Task<Professor> CriarAsync(Professor professor);
        Task<Professor?> ObterPorIdAsync(int id);
        Task<IEnumerable<Professor>> ObterTodosAsync();
        Task<Professor?> AtualizarAsync(Professor professor);
        Task<bool> ExcluirAsync(int id);
    }
}
