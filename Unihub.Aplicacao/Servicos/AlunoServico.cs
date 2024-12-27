using AutoMapper;
using Unihub.Aplicacao.DTOs;
using Unihub.Dominio.Entidades;
using Unihub.Dominio.Interfaces;

namespace Unihub.Aplicacao.Servicos
{
    public class AlunoServico : IAlunoServico
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly IMapper _mapper;

        public AlunoServico(IAlunoRepositorio alunoRepositorio, IMapper mapper)
        {
            _alunoRepositorio = alunoRepositorio;
            _mapper = mapper;
        }

        public async Task<AlunoDto> CriarAsync(AlunoAlteracaoDto dto)
        {
            var entidade = _mapper.Map<Aluno>(dto);
            await _alunoRepositorio.CriarAsync(entidade);
            return _mapper.Map<AlunoDto>(entidade);
        }

        public async Task<AlunoDto?> ObterPorIdAsync(int id)
        {
            var aluno = await _alunoRepositorio.ObterPorIdAsync(id);
            if (aluno == null) return null;
            return _mapper.Map<AlunoDto>(aluno);
        }

        public async Task<List<AlunoDto>> ObterTodosAsync()
        {
            var alunos = await _alunoRepositorio.ObterTodosAsync();
            return _mapper.Map<List<AlunoDto>>(alunos);
        }

        public async Task<AlunoDto?> AtualizarAsync(int id, AlunoAlteracaoDto dto)
        {
            var alunoExistente = await _alunoRepositorio.ObterPorIdAsync(id);
            if (alunoExistente == null) return null;

            _mapper.Map(dto, alunoExistente);

            var alunoAtualizado = await _alunoRepositorio.AtualizarAsync(alunoExistente);
            if (alunoAtualizado == null) return null;

            return _mapper.Map<AlunoDto>(alunoAtualizado);
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            return await _alunoRepositorio.ExcluirAsync(id);
        }

        public async Task<IEnumerable<DisciplinaDto>> ObterDisciplinasAsync(int alunoId)
        {
            var disciplinas = await _alunoRepositorio.ObterDisciplinasAsync(alunoId);
            return _mapper.Map<IEnumerable<DisciplinaDto>>(disciplinas);
        }
    }
}
