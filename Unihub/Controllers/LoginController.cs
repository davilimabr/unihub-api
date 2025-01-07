using Microsoft.AspNetCore.Mvc;
using Unihub.Aplicacao.DTOs;
using Unihub.Dominio.Interfaces;

namespace Unihub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAlunoServico _alunoServico;
        public LoginController(IAlunoServico alunoServico)
        {
            _alunoServico = alunoServico;
        }

        [HttpPost]
        [Route("Cadastro")]
        public async Task<ActionResult<bool>> Cadastrar([FromBody] AlunoAlteracaoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return await _alunoServico.CadastrarAsync(dto);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Logar([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return await _alunoServico.LogarAsync(dto);
        }
    }
}
