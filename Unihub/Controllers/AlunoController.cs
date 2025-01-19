using Microsoft.AspNetCore.Mvc;
using Unihub.Aplicacao.DTOs;
using Unihub.Dominio.Interfaces;

namespace Unihub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoServico _alunoServico;

        public AlunoController(IAlunoServico alunoServico)
        {
            _alunoServico = alunoServico;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AlunoDto>> ObterAlunoPorId(int id)
        {
            var aluno = await _alunoServico.ObterPorIdAsync(id);
            if (aluno == null) return NotFound();

            return Ok(aluno);
        }

        [HttpGet]
        public async Task<ActionResult<List<AlunoDto>>> ObterTodosAlunos()
        {
            var alunos = await _alunoServico.ObterTodosAsync();
            return Ok(alunos);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AlunoDto>> AtualizarAluno(int id, [FromBody] AlunoAlteracaoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var alunoAtualizado = await _alunoServico.AtualizarAsync(id, dto);
            if (alunoAtualizado == null) return NotFound();

            return Ok(alunoAtualizado);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> ExcluirAluno(int id)
        {
            var excluido = await _alunoServico.ExcluirAsync(id);
            if (!excluido) return NotFound();

            return NoContent();
        }

        [HttpPost("{id:int}/Disciplina")]
        public async Task<ActionResult<IEnumerable<AlunosDisciplinaDto>>> AdicionarDisciplinas(int id, [FromBody] IEnumerable<int> idsDisciplina)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var alunosDisciplinas = await _alunoServico.AdicionarDisciplinas(id, idsDisciplina);

            return Ok(alunosDisciplinas);
        }

        [HttpGet("{id:int}/Disciplina")]
        public async Task<ActionResult<IEnumerable<DisciplinaDto>>> ObterDisciplinas(int id)
        {
            var disciplinas = await _alunoServico.ObterDisciplinasAsync(id);
            return Ok(disciplinas);
        }

        [HttpDelete("{id:int}/Disciplina")]
        public async Task<IActionResult> DesinscreverAluno(int id, [FromBody] IEnumerable<int> idsDisciplinas)
        {
            await _alunoServico.RemoverDisciplinas(id, idsDisciplinas);

            return NoContent();
        }
    }
}
