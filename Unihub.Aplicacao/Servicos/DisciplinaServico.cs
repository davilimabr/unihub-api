using AutoMapper;
using Unihub.Aplicacao.DTOs;
using Unihub.Aplicacao.Interfaces;
using Unihub.Dominio.Entidades;
using Unihub.Dominio.Interfaces;

namespace Unihub.Aplicacao.Servicos
{
    public class DisciplinaServico : IDisciplinaServico
    {
        private readonly IDisciplinaRepositorio _repositorio;
        private readonly IFaltaRepositorio _repositorioFalta;
        private readonly IMapper _mapper;

        public DisciplinaServico(IDisciplinaRepositorio repositorio, IFaltaRepositorio faltaRepositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _repositorioFalta = faltaRepositorio;
        }

        public async Task<DisciplinaDto> CriarAsync(DisciplinaAlteracaoDto dto)
        {
            var entidade = _mapper.Map<Disciplina>(dto);
            var disciplinaCriada = await _repositorio.CriarAsync(entidade);
            return _mapper.Map<DisciplinaDto>(disciplinaCriada);
        }

        public async Task<DisciplinaDetalheDto?> ObterPorIdAsync(int id)
        {
            var disciplina = await _repositorio.ObterPorIdAsync(id);
            if (disciplina == null) return null;
            return _mapper.Map<DisciplinaDetalheDto>(disciplina);
        }

        public async Task<IEnumerable<DisciplinaDto>> ObterTodasAsync()
        {
            var disciplinas = await _repositorio.ObterTodasAsync();
            return _mapper.Map<List<DisciplinaDto>>(disciplinas);
        }

        public async Task<DisciplinaDto?> AtualizarAsync(int id, DisciplinaAlteracaoDto dto)
        {
            var disciplinaExistente = await _repositorio.ObterPorIdAsync(id);
            if (disciplinaExistente == null) return null;

            _mapper.Map(dto, disciplinaExistente);
            var disciplinaAtualizada = await _repositorio.AtualizarAsync(disciplinaExistente);
            if (disciplinaAtualizada == null) return null;

            return _mapper.Map<DisciplinaDto>(disciplinaAtualizada);
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            return await _repositorio.ExcluirAsync(id);
        }

        public async Task<IEnumerable<AlunoDto>> ObterAlunosInscritosAsync(int idDisciplina)
        {
            var alunos = await _repositorio.ObterAlunosInscritosAsync(idDisciplina);
            return _mapper.Map<IEnumerable<AlunoDto>>(alunos);
        }

        public async Task<IEnumerable<AlunosDisciplinaDto>> InscreverAlunoAsync(int idDisciplina, IEnumerable<int> idAluno)
        {
            var alunoDisciplina = await _repositorio.InscreverAlunoAsync(idDisciplina, idAluno);
            return _mapper.Map<IEnumerable<AlunosDisciplinaDto>>(alunoDisciplina);
        }

        public async Task DesinscreverAlunosAsync(int idDisciplina, IEnumerable<int> idsAlunos)
        {
            await _repositorio.DesinscreverAlunosAsync(idDisciplina, idsAlunos);
        }

        public async Task<IEnumerable<DisciplinaDto>> ObterPorAluno(int idAluno)
        {
            var disciplinas = await _repositorio.ObterPorAluno(idAluno);
            return _mapper.Map<IEnumerable<DisciplinaDto>>(disciplinas);
        }

        public async Task<FaltaDto> RegistrarFalta(int idDisciplina, FaltaAlteracaoDto falta)
        {
            var entidade = _mapper.Map<Falta>(falta);
            var faltaCriada = await _repositorioFalta.RegistrarFalta(entidade);
            return _mapper.Map<FaltaDto>(faltaCriada);
        }
    }
}
