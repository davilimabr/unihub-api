using Unihub.Dominio.Entidades;

namespace Unihub.Dominio.Interfaces
{
    public interface IAtividadeRepositorio
    {
        Task<Atividade> CriarAsync(Atividade atividade);
        Task<Atividade?> ObterPorIdAsync(int id);
        Task<List<Atividade>> ObterTodasAsync();
        Task<Atividade?> AtualizarAsync(Atividade atividade);
        Task<bool> ExcluirAsync(int id);
    }
}
