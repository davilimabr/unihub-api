using Microsoft.EntityFrameworkCore;
using Unihub.Dominio.Entidades;
using Unihub.Dominio.Interfaces;
using Unihub.Infraestrutura.Contexto;

namespace Unihub.Infraestrutura.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly AppDbContext _context;

        public AlunoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Aluno> CriarAsync(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }
        public async Task<IEnumerable<Aluno>> ObterAsync(Func<Aluno, bool> condicao)
        {
            return await Task.FromResult(
                _context.Aluno.Where(condicao).ToList()
                );
        }

        public async Task<Aluno?> ObterPorIdAsync(int id)
        {
            return await _context.Aluno.FindAsync(id);
        }

        public async Task<IEnumerable<Aluno>> ObterTodosAsync()
        {
            return await _context.Aluno.ToListAsync();
        }

        public async Task<Aluno?> AtualizarAsync(Aluno aluno)
        {
            var alunoExistente = await _context.Aluno.FindAsync(aluno.Id);
            if (alunoExistente == null)
            {
                return null;
            }

            _context.Entry(alunoExistente).CurrentValues.SetValues(aluno);

            await _context.SaveChangesAsync();
            return alunoExistente;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return false;
            }

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Disciplina>> ObterDisciplinasAsync(int alunoId)
        {
            var query = from ad in _context.AlunosDisciplina
                        join d in _context.Disciplina.Include(d => d.Faltas) on ad.DisciplinaId equals d.Id
                        where ad.AlunoId == alunoId
                        select d;

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Falta>> ObterFaltasAsync(int alunoId)
        {
            throw new NotImplementedException();
            // A entidade Falta tem a prop AlunoId, então é mais simples:
            //return await _context.Set<Falta>()
            //    .Where(f => f.AlunoId == alunoId)
            //    .ToListAsync();
        }

        /// <summary>
        /// Retorna todas as atividades que o Aluno (id=alunoId) possui.
        /// </summary>
        public async Task<IEnumerable<Atividade>> ObterAtividadesAsync(int alunoId)
        {
            return await _context.Atividade
                .Where(a => a.AlunoId == alunoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<AlunosDisciplina>> AdicionarDisciplinas(int idAluno, IEnumerable<int> idsDisciplina)
        {
            var alunosDisciplinas = new List<AlunosDisciplina>();

            var alunoExistente = await _context.Aluno.AnyAsync(x => x.Id == idAluno);
            if (!alunoExistente)
                return alunosDisciplinas;

            foreach (var idDisciplina in idsDisciplina)
            {
                var relacionamentoExistente = await _context.AlunosDisciplina.AnyAsync(x => x.DisciplinaId == idDisciplina);
                var disciplinaExistente = await _context.Disciplina.AnyAsync(x => x.Id == idDisciplina);

                if (!relacionamentoExistente && disciplinaExistente)
                {
                    var alunoDisciplina = new AlunosDisciplina(idAluno, idDisciplina);
                    _context.AlunosDisciplina.Add(alunoDisciplina);
                    await _context.SaveChangesAsync();
                    alunosDisciplinas.Add(alunoDisciplina);
                }
            }

            return alunosDisciplinas;
        }
    }
}
