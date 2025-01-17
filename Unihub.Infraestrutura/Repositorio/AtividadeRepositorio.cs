using Microsoft.EntityFrameworkCore;
using Unihub.Dominio.Entidades;
using Unihub.Dominio.Interfaces;
using Unihub.Infraestrutura.Contexto;

namespace Unihub.Infraestrutura.Repositorio
{
    public class AtividadeRepositorio : IAtividadeRepositorio
    {
        private readonly AppDbContext _context;

        public AtividadeRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Atividade> CriarAsync(Atividade atividade)
        {
            _context.Set<Atividade>().Add(atividade);
            await _context.SaveChangesAsync();
            return atividade;
        }

        public async Task<Atividade?> ObterPorIdAsync(int id)
        {
            return await _context.Set<Atividade>()
                .Include(a => a.Aluno)
                .Include(a => a.Disciplina)
                .Include(a => a.Nota)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Atividade>> ObterTodasAsync()
        {
            return await _context.Set<Atividade>().ToListAsync();
        }

        public async Task<Atividade?> AtualizarAsync(Atividade atividade)
        {
            var atividadeExistente = await _context.Set<Atividade>().FindAsync(atividade.Id);
            if (atividadeExistente == null)
                return null;

            _context.Entry(atividadeExistente).CurrentValues.SetValues(atividade);
            await _context.SaveChangesAsync();
            return atividadeExistente;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var atividade = await _context.Set<Atividade>().FindAsync(id);
            if (atividade == null)
                return false;

            _context.Set<Atividade>().Remove(atividade);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Atividade>> ObterPorAluno(int idAluno)
        {
            return await _context.Atividade
                .Include(a => a.Aluno)
                .Include(a => a.Disciplina)
                .Include(a => a.Nota)
                .Where(a => a.Aluno.Id == idAluno)
                .ToListAsync();
        }
    }
}
