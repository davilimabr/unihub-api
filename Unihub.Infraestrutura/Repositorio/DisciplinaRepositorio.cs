using Microsoft.EntityFrameworkCore;
using Unihub.Dominio.Entidades;
using Unihub.Dominio.Interfaces;
using Unihub.Infraestrutura.Contexto;

namespace Unihub.Infraestrutura.Repositorio
{
    public class DisciplinaRepositorio : IDisciplinaRepositorio
    {
        private readonly AppDbContext _context;

        public DisciplinaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Disciplina> CriarAsync(Disciplina disciplina)
        {
            _context.Disciplina.Add(disciplina);
            await _context.SaveChangesAsync();
            return disciplina;
        }

        public async Task<Disciplina?> ObterPorIdAsync(int id)
        {
            return await _context.Disciplina
                .Include(d => d.Professor)
                .Include(d => d.AulasNaSemanas)
                .Include(d => d.Atividades)
                .Include(d => d.AlunosDisciplinas)
                .Include(d => d.Faltas)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Disciplina>> ObterTodasAsync()
        {
            return await _context.Disciplina
                .Include(d => d.Professor)
                .Include(d => d.AulasNaSemanas)
                .Include(d => d.Atividades)
                .Include(d => d.AlunosDisciplinas)
                .Include(d => d.Faltas)
                .ToListAsync();
        }

        public async Task<Disciplina?> AtualizarAsync(Disciplina disciplina)
        {
            var disciplinaExistente = await _context.Disciplina.FindAsync(disciplina.Id);
            if (disciplinaExistente == null)
                return null;

            _context.Entry(disciplinaExistente).CurrentValues.SetValues(disciplina);
            await _context.SaveChangesAsync();
            return disciplinaExistente;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var disciplina = await _context.Disciplina.FindAsync(id);
            if (disciplina == null)
                return false;

            _context.Disciplina.Remove(disciplina);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<HorarioAula>> ObterHorariosAulas(int idDisciplina)
        {
            return await _context.HorarioAula
                .Include(x => x.AulasNaSemanas.Where(x => x.DisciplinaId == idDisciplina))
                .ToListAsync();
        }

        public async Task<HorarioAula> CriarHorarioAulaAsync(int idDisciplina, HorarioAula horarioAula)
        {
            _context.HorarioAula.Add(horarioAula);
            await _context.SaveChangesAsync();

            var aulaNaSemana = new AulasNaSemana(idDisciplina, horarioAula.Id);
            _context.AulasNaSemana.Add(aulaNaSemana);

            await _context.SaveChangesAsync();

            return horarioAula;
        }

        public async Task<bool> ExcluirHorarioAulaAsync(int idHorarioAula)
        {
            var horarioAula = await _context.HorarioAula.FindAsync(idHorarioAula);
            if (horarioAula == null)
                return false;

            _context.HorarioAula.Remove(horarioAula);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
