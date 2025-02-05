﻿using Unihub.Aplicacao.DTOs;

namespace Unihub.Dominio.Interfaces
{
    public interface IAlunoServico
    {
        Task<bool> CadastrarAsync(AlunoAlteracaoDto dto);
        Task<LoginRetornoDto> LogarAsync(LoginDto dto);
        Task<AlunoDto?> ObterPorIdAsync(int id);
        Task<List<AlunoDto>> ObterTodosAsync();
        Task<AlunoDto?> AtualizarAsync(int id, AlunoAlteracaoDto dto);
        Task<bool> ExcluirAsync(int id);
        Task<IEnumerable<DisciplinaDto>> ObterDisciplinasAsync(int alunoId);
        Task<IEnumerable<AlunosDisciplinaDto>> AdicionarDisciplinas(int idAluno, IEnumerable<int> idDisciplina);
        Task RemoverDisciplinas(int idAluno, IEnumerable<int> idsDisciplinas);
    }
}
