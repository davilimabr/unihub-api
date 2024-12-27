using AutoMapper;
using Unihub.Aplicacao.DTOs;
using Unihub.Aplicacao.Interfaces;
using Unihub.Dominio.Entidades;
using Unihub.Dominio.Interfaces;

namespace Unihub.Aplicacao.Servicos
{
    public class ProfessorServico : IProfessorServico
    {
        private readonly IProfessorRepositorio _professorRepositorio;
        private readonly IMapper _mapper;

        public ProfessorServico(IProfessorRepositorio professorRepositorio, IMapper mapper)
        {
            _professorRepositorio = professorRepositorio;
            _mapper = mapper;
        }

        public async Task<ProfessorDto> CriarAsync(ProfessorAlteracaoDto dto)
        {
            var entidade = _mapper.Map<Professor>(dto);
            var professorCriado = await _professorRepositorio.CriarAsync(entidade);
            return _mapper.Map<ProfessorDto>(professorCriado);
        }

        public async Task<ProfessorDto?> ObterPorIdAsync(int id)
        {
            var professor = await _professorRepositorio.ObterPorIdAsync(id);
            if (professor == null) return null;
            return _mapper.Map<ProfessorDto>(professor);
        }

        public async Task<List<ProfessorDto>> ObterTodosAsync()
        {
            var professores = await _professorRepositorio.ObterTodosAsync();
            return _mapper.Map<List<ProfessorDto>>(professores);
        }

        public async Task<ProfessorDto?> AtualizarAsync(int id, ProfessorAlteracaoDto dto)
        {
            var professorExistente = await _professorRepositorio.ObterPorIdAsync(id);
            if (professorExistente == null) return null;

            _mapper.Map(dto, professorExistente);
            var professorAtualizado = await _professorRepositorio.AtualizarAsync(professorExistente);
            if (professorAtualizado == null) return null;

            return _mapper.Map<ProfessorDto>(professorAtualizado);
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            return await _professorRepositorio.ExcluirAsync(id);
        }
    }
}
