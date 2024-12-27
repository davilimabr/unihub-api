using Microsoft.AspNetCore.Mvc;
using Unihub.Aplicacao.DTOs;
using Unihub.Aplicacao.Interfaces;

namespace Unihub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorServico _professorServico;

        public ProfessorController(IProfessorServico professorServico)
        {
            _professorServico = professorServico;
        }

        [HttpPost]
        public async Task<ActionResult<ProfessorDto>> CriarProfessor([FromBody] ProfessorAlteracaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var professorCriado = await _professorServico.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterProfessorPorId), new { id = professorCriado.Id }, professorCriado);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProfessorDto>> ObterProfessorPorId(int id)
        {
            var professor = await _professorServico.ObterPorIdAsync(id);
            if (professor == null)
                return NotFound();

            return Ok(professor);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProfessorDto>>> ObterTodosProfessores()
        {
            var professores = await _professorServico.ObterTodosAsync();
            return Ok(professores);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProfessorDto>> AtualizarProfessor(int id, [FromBody] ProfessorAlteracaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var professorAtualizado = await _professorServico.AtualizarAsync(id, dto);
            if (professorAtualizado == null)
                return NotFound();

            return Ok(professorAtualizado);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> ExcluirProfessor(int id)
        {
            var excluido = await _professorServico.ExcluirAsync(id);
            if (!excluido)
                return NotFound();

            return NoContent();
        }
    }
}
