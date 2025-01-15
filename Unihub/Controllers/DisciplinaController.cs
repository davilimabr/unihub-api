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

        [HttpGet("{id:int}/Aluno")]
        public async Task<ActionResult<IEnumerable<AlunoDto>>> ObterAlunosInscritos(int id)
        {
            var alunos = await _servico.ObterAlunosInscritosAsync(id);
            return Ok(alunos);
        }

        [HttpPost("{id:int}/Aluno")]
        public async Task<ActionResult<IEnumerable<AlunosDisciplinaDto>>> ObterAlunosInscritos(int id, [FromBody] IEnumerable<int> idAlunos)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var alunosDisciplinas = await _servico.InscreverAlunoAsync(id, idAlunos);

            return Ok(alunosDisciplinas);
        }

        [HttpDelete("{id:int}/Aluno")]
        public async Task<IActionResult> DesinscreverAluno(int id, [FromBody] IEnumerable<int> idAlunos)
        {
            await _servico.DesinscreverAlunosAsync(id, idAlunos);
            
            return NoContent();
        }

        [HttpPost("{idDiscioplina:int}/Aluno/{idAluno:int}/Falta")]
        public async Task<ActionResult<FaltaDto>> RegistrarFalta(int idDiscioplina, int idAluno, [FromBody] FaltaAlteracaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dto.AlunoId = idAluno;
            dto.DisciplinaId = idDiscioplina;

            var falta = await _servico.RegistrarFalta(idDiscioplina, dto);

            return Ok(falta);
        }
    }
}
