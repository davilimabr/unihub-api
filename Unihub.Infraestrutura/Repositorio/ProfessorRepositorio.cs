using Microsoft.EntityFrameworkCore;
using Unihub.Dominio.Entidades;
using Unihub.Dominio.Interfaces;
using Unihub.Infraestrutura.Contexto;

namespace Unihub.Infraestrutura.Repositorio
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly AppDbContext _context;

        public ProfessorRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Professor> CriarAsync(Professor professor)
        {
            _context.Professor.Add(professor);
            await _context.SaveChangesAsync();
            return professor;
        }

        public async Task<Professor?> ObterPorIdAsync(int id)
        {
            return await _context.Professor
                .Include(p => p.Disciplinas) 
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Professor>> ObterTodosAsync()
        {
            return await _context.Professor.ToListAsync();
        }

        public async Task<Professor?> AtualizarAsync(Professor professor)
        {
            var professorExistente = await _context.Professor.FindAsync(professor.Id);
            if (professorExistente == null)
                return null;

            _context.Entry(professorExistente).CurrentValues.SetValues(professor);

            await _context.SaveChangesAsync();
            return professorExistente;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var professor = await _context.Professor.FindAsync(id);
            if (professor == null)
                return false;

            _context.Professor.Remove(professor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
