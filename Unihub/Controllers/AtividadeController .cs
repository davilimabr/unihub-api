using Microsoft.AspNetCore.Mvc;
using Unihub.Aplicacao.DTOs;
using Unihub.Aplicacao.Interfaces;

namespace Unihub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly IAtividadeServico _servico;

        public AtividadeController(IAtividadeServico servico)
        {
            _servico = servico;
        }

        [HttpPost]
        public async Task<ActionResult<AtividadeDto>> Criar([FromBody] AtividadeAlteracaoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atividadeCriada = await _servico.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = atividadeCriada.Id }, atividadeCriada);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AtividadeDetalhesDto>> ObterPorId(int id)
        {
            var atividade = await _servico.ObterPorIdAsync(id);
            if (atividade == null) return NotFound();
            return Ok(atividade);
        }

        [HttpGet]
        public async Task<ActionResult<List<AtividadeDto>>> ObterTodas()
        {
            var atividades = await _servico.ObterTodasAsync();
            return Ok(atividades);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AtividadeDto>> Atualizar(int id, [FromBody] AtividadeAlteracaoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atividadeAtualizada = await _servico.AtualizarAsync(id, dto);
            if (atividadeAtualizada == null) return NotFound();

            return Ok(atividadeAtualizada);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var excluido = await _servico.ExcluirAsync(id);
            if (!excluido) return NotFound();
            return NoContent();
        }
    }
}
