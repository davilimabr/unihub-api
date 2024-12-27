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

        [HttpPost]
        public async Task<ActionResult<AlunoDto>> CriarAluno([FromBody] AlunoAlteracaoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var resultado = await _alunoServico.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterAlunoPorId), new { id = resultado.Id }, resultado);
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
    }
}
