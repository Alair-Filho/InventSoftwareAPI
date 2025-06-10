using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InventSoftwareAPI.Models;
using InventSoftwareAPI.Repositories;

namespace InventSoftwareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        private readonly IEquipamentoRepository _repositorio;

        public EquipamentosController(IEquipamentoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public IActionResult GetTodos()
        {
            return Ok(_repositorio.ObterTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(Guid id)
        {
            var equipamento = _repositorio.ObterPorId(id);

            if (equipamento == null) return NotFound();
            return Ok(equipamento);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] EquipamentoEletronico novoEquipamento)
        {
            _repositorio.Adicionar(novoEquipamento);
            return CreatedAtAction(nameof(GetPorId), new { id = novoEquipamento.Id }, novoEquipamento);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] EquipamentoEletronico atualizado)
        {
            if (id != atualizado.Id) return BadRequest();
            _repositorio.Atualizar(atualizado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            _repositorio.Remover(id);
            return NoContent();
        }
    }
}
