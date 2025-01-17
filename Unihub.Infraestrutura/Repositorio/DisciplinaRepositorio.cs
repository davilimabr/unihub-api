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
                .Include(d => d.Atividades)
                .Include(d => d.AlunosDisciplinas)
                .Include(d => d.Faltas)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Disciplina>> ObterTodasAsync()
        {
            return await _context.Disciplina
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

        public async Task<IEnumerable<Aluno>> ObterAlunosInscritosAsync(int idDisciplina)
        {
            return await _context.AlunosDisciplina
                .Where(x => x.DisciplinaId == idDisciplina)
                .Select(x => x.Aluno)
                .ToListAsync();
        }

        public async Task<IEnumerable<AlunosDisciplina>> InscreverAlunoAsync(int idDisciplina, IEnumerable<int> idsAlunos)
        {
            var alunosDisciplinas = new List<AlunosDisciplina>();

            foreach(var idAluno in idsAlunos)
            {
                var relacionamentoExistente = await _context.AlunosDisciplina.AnyAsync(x => x.AlunoId == idAluno);
                var alunoExistente = await _context.Aluno.AnyAsync(x => x.Id == idAluno);

                if (!relacionamentoExistente && alunoExistente)
                {
                    var alunoDisciplina = new AlunosDisciplina(idAluno, idDisciplina);
                    _context.AlunosDisciplina.Add(alunoDisciplina);
                    await _context.SaveChangesAsync();
                    alunosDisciplinas.Add(alunoDisciplina);
                }
            }

            return alunosDisciplinas;
        }

        public async Task DesinscreverAlunosAsync(int idDisciplina, IEnumerable<int> idsAlunos)
        {
            foreach (var idAluno in idsAlunos)
            {
                var alunoDisciplina = await _context.AlunosDisciplina.Where(x => x.DisciplinaId == idDisciplina && x.AlunoId == idAluno).FirstOrDefaultAsync();
                
                if (alunoDisciplina is null)
                    return;
                
                _context.AlunosDisciplina.Remove(alunoDisciplina!);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Disciplina>> ObterPorAluno(int idAluno)
        {
            return await _context.Disciplina
                .Include(d => d.Professor)
                .Include(d => d.Atividades)
                .Include(d => d.AlunosDisciplinas.Where(a => a.AlunoId == idAluno))
                .Include(d => d.Faltas)
                .ToListAsync();
        }
    }
}
