using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Unihub.Aplicacao.DTOs;
using Unihub.Dominio.Interfaces;
using unihub_api.Dominio.Entidades;
using unihub_api.Infraestrutura.Configuracao;

namespace Unihub.Aplicacao.Servicos
{
    public class AlunoServico : IAlunoServico
    {
        private readonly AppDbContext _context; 
        private readonly IMapper _mapper;

        public AlunoServico(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AlunoDto> CriarAsync(AlunoAlteracaoDto dto)
        {
            var aluno = _mapper.Map<Aluno>(dto);
            _context.Set<Aluno>().Add(aluno);
            await _context.SaveChangesAsync();
            return _mapper.Map<AlunoDto>(aluno);
        }

        public async Task<AlunoDto?> ObterPorIdAsync(int id)
        {
            var aluno = await _context.Set<Aluno>().FindAsync(id);
            if (aluno == null)
            {
                return null;
            }
            return _mapper.Map<AlunoDto>(aluno);
        }

        public async Task<List<AlunoDto>> ObterTodosAsync()
        {
            var alunos = await _context.Set<Aluno>().ToListAsync();
            return _mapper.Map<List<AlunoDto>>(alunos);
        }

        public async Task<AlunoDto?> AtualizarAsync(int id, AlunoAlteracaoDto dto)
        {
            var alunoExistente = await _context.Set<Aluno>().FindAsync(id);
            if (alunoExistente == null)
                throw new Exception("Aluno não existente!");

           _mapper.Map(dto, alunoExistente);

            await _context.SaveChangesAsync();
            return _mapper.Map<AlunoDto>(alunoExistente);
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var aluno = await _context.Set<Aluno>().FindAsync(id);
            if (aluno == null)
            {
                return false;
            }

            _context.Set<Aluno>().Remove(aluno);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
