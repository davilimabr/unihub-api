using Microsoft.AspNetCore.Mvc;
using Unihub.Aplicacao.DTOs;
using Unihub.Aplicacao.Interfaces;

namespace Unihub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaServico _servico;

        public DisciplinaController(IDisciplinaServico servico)
        {
            _servico = servico;
        }

        [HttpPost]
        public async Task<ActionResult<DisciplinaDto>> Criar([FromBody] DisciplinaAlteracaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var disciplina = await _servico.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = disciplina.Id }, disciplina);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DisciplinaDto>> ObterPorId(int id)
        {
            var disciplina = await _servico.ObterPorIdAsync(id);
            if (disciplina == null) return NotFound();
            return Ok(disciplina);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplinaDto>>> ObterTodas()
        {
            var disciplinas = await _servico.ObterTodasAsync();
            return Ok(disciplinas);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<DisciplinaDto>> Atualizar(int id, [FromBody] DisciplinaAlteracaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var disciplinaAtualizada = await _servico.AtualizarAsync(id, dto);
            if (disciplinaAtualizada == null) return NotFound();
            return Ok(disciplinaAtualizada);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var excluido = await _servico.ExcluirAsync(id);
            if (!excluido) return NotFound();
            return NoContent();
        }

        [HttpGet("{id:int}/horario")]
        public async Task<ActionResult<IEnumerable<DisciplinaDto>>> ObterHorariosAula(int id)
        {
            var disciplinas = await _servico.ObterHorariosAulasAsync(id);
            return Ok(disciplinas);
        }

        [HttpPost("{id:int}/horario")]
        public async Task<ActionResult<HorarioAulaAlteracaoDto>> CriarHorarioAula(int id, [FromBody] HorarioAulaAlteracaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _servico.CriarHorarioAulaAsync(id, dto);
        }

        [HttpDelete("/Horario/{id:int}")]
        public async Task<IActionResult> ExcluirHorarioAula(int id)
        {
            var excluido = await _servico.ExcluirHorariosAulaAsync(id);
            if (!excluido) return NotFound();
            return NoContent();
        }
    }
}
