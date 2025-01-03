using AutoMapper;
using Unihub.Aplicacao.DTOs;
using Unihub.Aplicacao.Interfaces;
using Unihub.Dominio.Entidades;
using Unihub.Dominio.Interfaces;

namespace Unihub.Aplicacao.Servicos
{
    public class AtividadeServico : IAtividadeServico
    {
        private readonly IAtividadeRepositorio _repositorio;
        private readonly IMapper _mapper;

        public AtividadeServico(IAtividadeRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<AtividadeDto> CriarAsync(AtividadeAlteracaoDto dto)
        {
            var entidade = _mapper.Map<Atividade>(dto);
            var atividadeCriada = await _repositorio.CriarAsync(entidade);
            return _mapper.Map<AtividadeDto>(atividadeCriada);
        }

        public async Task<AtividadeDetalhesDto?> ObterPorIdAsync(int id)
        {
            var atividade = await _repositorio.ObterPorIdAsync(id);
            if (atividade == null) return null;
            return _mapper.Map<AtividadeDetalhesDto>(atividade);
        }

        public async Task<List<AtividadeDto>> ObterTodasAsync()
        {
            var atividades = await _repositorio.ObterTodasAsync();
            return _mapper.Map<List<AtividadeDto>>(atividades);
        }

        public async Task<AtividadeDto?> AtualizarAsync(int id, AtividadeAlteracaoDto dto)
        {
            var atividadeExistente = await _repositorio.ObterPorIdAsync(id);
            if (atividadeExistente == null) return null;

            _mapper.Map(dto, atividadeExistente);
            var atividadeAtualizada = await _repositorio.AtualizarAsync(atividadeExistente);
            if (atividadeAtualizada == null) return null;

            return _mapper.Map<AtividadeDto>(atividadeAtualizada);
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            return await _repositorio.ExcluirAsync(id);
        }
    }
}
